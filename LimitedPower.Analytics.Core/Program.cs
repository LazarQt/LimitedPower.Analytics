using LimitedPower.Analytics.Core;
using RestSharp;
using LimitedPower.Analytics.Models;

Console.WriteLine("Start Analytics Testing");


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

var remote = new SeventeenLandsApi(new RestClient(Const.SeventeenLandsBaseUrl));
var crawler = new DataCrawler(remote);

crawler.DoAnalytics();
return;
foreach (var draftType in Enum.GetValues(typeof(DraftType)).Cast<DraftType>())
{
    crawler.UpdateTrophyDecks(Set.BRO, draftType);
}


Console.WriteLine("End Analytics Testing");