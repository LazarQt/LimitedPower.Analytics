using System.Text.Json.Serialization;

namespace LimitedPower.Analytics.Models
{
    public class AnalyticsResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public AnalyticsResponse(string message)
        {
            Name = message;
        }
    }
}
