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

        public void DeleteCardRatings()
        {
            _liteDb.GetCollection<CardRating>(Const.Db.CardRatingsTable).Delete(e => true);
        }

        public void UpdateCardRatings(Set set, DraftType draftType, DataTimespan dataTimespan, ColorCombination colorCombination)
        {
            var endDate = DateTime.Now;

            var startDate = dataTimespan switch
            {
                DataTimespan.All => DateTime.MinValue,
                DataTimespan.Recent => endDate.AddDays(Const.RecentDays),
                _ => DateTime.MinValue
            };

            var cardRatingsColumn = _liteDb.GetCollection<CardRating>(Const.Db.CardRatingsTable);
            cardRatingsColumn.InsertBulk(GatherCardRatingsData(set, draftType, startDate, endDate, dataTimespan, colorCombination));

            Console.WriteLine($"Updated card ratings for {draftType} ({dataTimespan}), color combination used: {colorCombination}");
        }

        public void DeleteTrophyDecks()
        {
#if DEBUG
            // NEVER execute on live data
            _liteDb.GetCollection<CardRating>(Const.Db.TrophyDecks).Delete(true);
#endif
        }

        public void UpdateTrophyDecks(Set set, DraftType draftType)
        {
            //var trophyDecksColumn = _liteDb.GetCollection<TrophyDeck>(Const.Db.TrophyDecks);

            var existingTrophyDecks = JsonSerializer.Deserialize<TrophyDeckModel[]>(File.ReadAllText($"{draftType}-{set}.json")).ToList();
            var existingTrophyDeckIds = existingTrophyDecks.Select(i => i.Id);

            var trophyDecks = GatherTrophyDecksData(set, draftType).ToList().Where(x=> !existingTrophyDeckIds.Contains(x.Id));
            foreach(var td in trophyDecks)
            {
                Console.WriteLine($"grabbing deck data for {td.Id}");
                var eventData = GatherLimitedEventData(td.Id, td.DeckIndex);
                td.Cards = eventData.Groups[0].Cards.Select(i => i.Name);

                existingTrophyDecks.Add(td);
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
            File.WriteAllText($"{draftType}-{set}.json", JsonSerializer.Serialize(existingTrophyDecks));

            Console.WriteLine($"Updated trophy decks for {draftType}");
        }

        public IEnumerable<TrophyDeck> GetUnsavedTrophyDecks()
        {
            var trophyDecksColumn = _liteDb.GetCollection<TrophyDeck>(Const.Db.TrophyDecks);
            return trophyDecksColumn.Find(d => d.LimitedEventSaved == false);
        }

        public void UpdateLimitedEvent(int trophyDeckId)
        {
            var trophyDecksColumn = _liteDb.GetCollection<TrophyDeck>(Const.Db.TrophyDecks);
            var limitedEventsColumns = _liteDb.GetCollection<LimitedEvent>(Const.Db.LimitedEvents);

            var trophyDeck = trophyDecksColumn.FindById(trophyDeckId);

            //var limitedEvent = GatherLimitedEventData(trophyDeck.Id, trophyDeck.DeckIndex);
            //limitedEventsColumns.Insert(limitedEvent);

            //trophyDeck.LimitedEventSaved = true;
            //trophyDecksColumn.Update(trophyDeck);
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

        public CardRating[] GatherCardRatingsData(Set set, DraftType draftType, DateTime start, DateTime end, DataTimespan dataTimespan, ColorCombination colorCombination)
        {
            var requestString = $"card_ratings/data?expansion={set.ToString().ToUpper()}" +
                                $"&format={draftType}&start_date={start.ToString(Const.DateFormat)}&end_date={end.ToString(Const.DateFormat)}";

            if (colorCombination != ColorCombination.None) requestString += $"&colors={colorCombination}";

            var cardsJson = _seventeenLandsApi.GetJson(requestString);
            var cardRatings = JsonSerializer.Deserialize<CardRating[]>(cardsJson);
            if (cardRatings == null)
            {
                // todo: log
                return Array.Empty<CardRating>();
            }

            foreach (var cardRating in cardRatings)
            {
                cardRating.DraftType = draftType;
                cardRating.DataTimespan = dataTimespan;
                cardRating.DeckColor = colorCombination;
            }

            return cardRatings;
        }
    }
}