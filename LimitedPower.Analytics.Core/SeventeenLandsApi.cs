using LimitedPower.Analytics.Models;
using RestSharp;

namespace LimitedPower.Analytics.Core
{
    public class SeventeenLandsApi
    {
        private readonly RestClient _client;

        public SeventeenLandsApi(RestClient client)
        {
            _client = client;
        }

        public string GetJson(string request)
        {
            var restRequest = new RestRequest(request);

            try
            {
                // todo: currently we just wait 16 seconds before execution to make sure we don't get rate limited, ask how long timeout really is maybe?
                Thread.Sleep(Const.RemoteGraceTime);
                var response = _client.Get(restRequest);
                if (response.Content != null) return response.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Can't execute request {request}, error: {e.Message}");
                Thread.Sleep(Const.RemoteGraceTime);
                return GetJson(request);
            }

            throw new Exception("empty");
        }
    }
}
