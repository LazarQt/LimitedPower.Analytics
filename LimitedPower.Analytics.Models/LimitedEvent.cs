using System.Text.Json.Serialization;

namespace LimitedPower.Analytics.Models
{
    public class LimitedEvent : LimitedEventModel
    {
        public int Id { get; set; }
    }

    public class LimitedEventModel
    {
        [JsonPropertyName("event_info")]
        public EventInfo EventInfo { get; set; }

        [JsonPropertyName("groups")]
        public Group[] Groups { get; set; }

        [JsonPropertyName("text_link")]
        public string TextLink { get; set; }

        [JsonPropertyName("builder_link")]
        public string BuilderLink { get; set; }

        [JsonPropertyName("initial_sort")]
        public string InitialSort { get; set; }

        [JsonPropertyName("castabilities")]
        public object Castabilities { get; set; }
    }

    public class EventInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("expansion")]
        public string Expansion { get; set; }

        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("pool_link")]
        public string PoolLink { get; set; }

        [JsonPropertyName("deck_links")]
        public string[] DeckLinks { get; set; }

        [JsonPropertyName("details_link")]
        public string DetailsLink { get; set; }

        [JsonPropertyName("streaming_enabled")]
        public bool StreamingEnabled { get; set; }

        [JsonPropertyName("draft_link")]
        public string DraftLink { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cards")]
        public Card[] Cards { get; set; }
    }

    public class Card
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cmc")]
        public float Cmc { get; set; }

        [JsonPropertyName("color_identity")]
        public string[] ColorIdentity { get; set; }

        [JsonPropertyName("mana_cost")]
        public string ManaCost { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("url_back")]
        public string UrlBack { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("types")]
        public string[] Types { get; set; }

        [JsonPropertyName("preview_direction")]
        public string PreviewDirection { get; set; }
    }

}
