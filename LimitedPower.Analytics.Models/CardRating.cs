using System.Text.Json.Serialization;

namespace LimitedPower.Analytics.Models
{
    public class CardRating : CardRatingModel
    {
        public int Id { get; set; }

        public DraftType DraftType { get; set; }
        public DataTimespan DataTimespan { get; set; }
        public ColorCombination DeckColor { get; set; }
    }

    public class CardRatingModel
    {
        [JsonPropertyName("seen_count")]
        public int Seen { get; set; }

        [JsonPropertyName("avg_seen")]
        public float? AverageSeen { get; set; }

        [JsonPropertyName("pick_count")]
        public int Pick { get; set; }

        [JsonPropertyName("avg_pick")]
        public float? AveragePick { get; set; }

        [JsonPropertyName("game_count")]
        public int Games { get; set; }

        [JsonPropertyName("win_rate")]
        public float? WinRate { get; set; }

        [JsonPropertyName("sideboard_game_count")]
        public int SideboardGames { get; set; }

        [JsonPropertyName("sideboard_win_rate")]
        public float? SideboardWinRate { get; set; }

        [JsonPropertyName("opening_hand_game_count")]
        public int OpeningHandGames { get; set; }

        [JsonPropertyName("opening_hand_win_rate")]
        public float? OpeningHandWinRate { get; set; }

        [JsonPropertyName("drawn_game_count")]
        public int DrawnGames { get; set; }

        [JsonPropertyName("drawn_win_rate")]
        public float? DrawWinRate { get; set; }

        [JsonPropertyName("ever_drawn_game_count")]
        public int EverDrawnGames { get; set; }

        [JsonPropertyName("ever_drawn_win_rate")]
        public float? EverDrawnWinRate { get; set; }

        [JsonPropertyName("never_drawn_game_count")]
        public int NeverDrawnGames { get; set; }

        [JsonPropertyName("never_drawn_win_rate")]
        public float? NeverDrawnWinRate { get; set; }

        [JsonPropertyName("drawn_improvement_win_rate")]
        public float? DrawnImprovementWinRate { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("url_back")]
        public string UrlBack { get; set; }
    }

}