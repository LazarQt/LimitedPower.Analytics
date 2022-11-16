using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace LimitedPower.Analytics.Models
{
    public class TrophyDeck : TrophyDeckModel
    {
        public int Id { get; set; }
        public bool LimitedEventSaved { get; set; } = false;
        public DraftType DraftType { get; set; }
        public Set Set { get; set; }
    }

    public class TrophyDeckModel
    {
        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("start_rank")]
        public string StartRank { get; set; }

        [JsonPropertyName("end_rank")]
        public string EndRank { get; set; }

        [JsonPropertyName("colors")]
        public string Colors { get; set; }

        [JsonPropertyName("aggregate_id")]
        public string Id { get; set; }

        [JsonPropertyName("deck_index")]
        public int DeckIndex { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        public IEnumerable<string> Cards { get; set; }
    }

}
