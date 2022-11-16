using LimitedPower.Analytics.Core;
using LiteDB;
using RestSharp;
using LimitedPower.Analytics.Models;
using System.Globalization;

Console.WriteLine("Start Analytics Testing");


// card download

//var sfClient = new RestClient();

//var setRequest = new RestRequest("https://api.scryfall.com/sets/dmu");
//var setResponse = sfClient.Get(setRequest);
//var sfSet = JsonSerializer.Deserialize<SetObject>(setResponse.Content);

//DlImages(sfClient, sfSet.search_uri);

//var webClient = new WebClient();

//static void DlImages(RestClient sfClient, string searchUri)
//{
//    var setSearchRequest = new RestRequest(searchUri);
//    var setSearchResponse = sfClient.Get(setSearchRequest);
//    var sfSetSearch = JsonSerializer.Deserialize<SetSearch>(setSearchResponse.Content);

//    foreach (var d in sfSetSearch.data)
//    {
//        if (Convert.ToInt32(d.collector_number) > 261) continue;
//        var client = new RestClient();
//        var imageRequest = new RestRequest(d.image_uris.normal);
//        var response = client.DownloadData(imageRequest);
//        Regex rgx = new Regex("[^a-zA-Z0-9-]");
//        var newName = $"{rgx.Replace(d.Name, "")}.jpg".ToLower();
//        File.WriteAllBytes(Path.Combine("img", newName), response);
//    }

//    if (sfSetSearch.has_more)
//    {
//        DlImages(sfClient, sfSetSearch.next_page);
//    }
//}

// card download end

//var da = new DataAnalyzer(new LiteDatabase(@"Filename=C:/dev/SeventeenLandsData.db;Connection=Shared"));
//da.Run("DMU");


//Console.WriteLine();




//var db = new LiteDatabase(@"Filename=C:/dev/SeventeenLandsData.db;Connection=Shared");

    var remote = new SeventeenLandsApi(new RestClient(Const.SeventeenLandsBaseUrl));
    var crawler = new DataCrawler(remote);

    foreach (var draftType in Enum.GetValues(typeof(DraftType)).Cast<DraftType>())
    {
        crawler.UpdateTrophyDecks(Set.BRO, draftType);
    }




// delete card ratings
//crawler.DeleteCardRatings();

//// save card ratings
//foreach (var colorCombination in Enum.GetValues(typeof(ColorCombination)).Cast<ColorCombination>())
//{
//    foreach (var draftType in Enum.GetValues(typeof(DraftType)).Cast<DraftType>())
//    {
//        foreach (var dataTimespan in Enum.GetValues(typeof(DataTimespan)).Cast<DataTimespan>())
//        {
//            crawler.UpdateCardRatings(Set.DMU, draftType, dataTimespan, colorCombination);
//        }
//    }
//}

////delete trophy decks
//crawler.DeleteTrophyDecks();

// update trophy decks


//// save corresponding limited event data
//var unsavedDecks = crawler.GetUnsavedTrophyDecks();
//foreach (var deck in unsavedDecks)
//{
//    crawler.UpdateLimitedEvent(deck.Id);
//}

Console.WriteLine("End Analytics Testing");