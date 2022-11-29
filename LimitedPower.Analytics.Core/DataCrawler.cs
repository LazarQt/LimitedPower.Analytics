using System.IO.Compression;
using LimitedPower.Analytics.Models;
using LiteDB;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LimitedPower.Analytics.Core
{
    public class DataCrawler
    {
        private readonly LiteDatabase _liteDb;
        private readonly SeventeenLandsApi _seventeenLandsApi;

        public DataCrawler(SeventeenLandsApi seventeenLandsApi)
        {
           
            _seventeenLandsApi = seventeenLandsApi;
        }

        public void UpdateTrophyDecks(Set set, DraftType draftType)
        {
            //var trophyDecksColumn = _liteDb.GetCollection<TrophyDeck>(Const.Db.TrophyDecks);

            var existingTrophyDecks = JsonSerializer.Deserialize<TrophyDeckModel[]>(File.ReadAllText($"{draftType}-{set}.json")).ToList();
            var existingTrophyDeckIds = existingTrophyDecks.Select(i => i.Id);
            var i = 0;
            var trophyDecks = GatherTrophyDecksData(set, draftType).ToList().Where(x=> !existingTrophyDeckIds.Contains(x.Id)).ToList();
            foreach(var td in trophyDecks)
            {
                i++;
                Console.WriteLine($"grabbing deck data {draftType} for {td.Id} ({i}/{trophyDecks.Count})");
                var eventData = GatherLimitedEventData(td.Id, td.DeckIndex);
                td.Cards = eventData.Groups[0].Cards.Select(i => i.Name);

                existingTrophyDecks.Add(td);
                File.WriteAllText($"{draftType}-{set}.json", JsonSerializer.Serialize(existingTrophyDecks));
            }
            //var aggregateIds = trophyDecks.Select(t => t.Id).ToList();
            //var exitingTrophyDeckEntries = trophyDecksColumn.Find(c => aggregateIds.Contains(c.Id))
            //    .Select(i => i.Id).ToList();

            //var newTrophyDecks = trophyDecks.Where(t => !exitingTrophyDeckEntries.Contains(t.Id)).ToList();

            //foreach (var trophyDeck in newTrophyDecks)
            //{
            //    trophyDeck.Set = set;
            //    trophyDeck.DraftType = draftType;
            //    trophyDecksColumn.Insert(trophyDeck);
            //}

            //var n = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //File.WriteAllText($"{draftType}-{set}.json", JsonSerializer.Serialize(existingTrophyDecks));

            Console.WriteLine($"Updated trophy decks for {draftType}");
        }

        public void DoAnalytics()
        {
            var tds = JsonSerializer.Deserialize<TrophyDeckModel[]>(File.ReadAllText($"d/PremierDraft-BRO.json")).ToList();
            tds = tds.Where(x=>x.EndRank != null && (x.EndRank.Contains("Diamond") || x.EndRank.Contains("Mythic"))).ToList();

            var colors = tds.GroupBy(d=>d.Colors).OrderByDescending(x=>x.Count()); 
            foreach(var c in colors)
            {
                Console.WriteLine($"{c.Key}->{c.Count()}");
            }
        }

        public TrophyDeckModel[] GatherTrophyDecksData(Set set, DraftType draftType)
        {
            var trophyDecksJson =
                _seventeenLandsApi.GetJson($"https://www.17lands.com/data/trophies?expansion={set}&format={draftType}");
            return JsonSerializer.Deserialize<TrophyDeckModel[]>(trophyDecksJson) ?? Array.Empty<TrophyDeckModel>();
        }

        public LimitedEventModel GatherLimitedEventData(string draftId, int deckIndex)
        {
            var limitedEventJson = _seventeenLandsApi.GetJson(
                $"https://www.17lands.com/data/deck?draft_id={draftId}&deck_index={deckIndex}");
            return JsonSerializer.Deserialize<LimitedEventModel>(limitedEventJson);
        }
    }
}