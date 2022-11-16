using System.Text.Json.Serialization;
// ReSharper disable InconsistentNaming

namespace LimitedPower.Analytics.Models
{
    public class SetSearch
    {
        public string _object { get; set; }
        public int total_cards { get; set; }
        public bool has_more { get; set; }
        public string next_page { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string _object { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string oracle_id { get; set; }
        public int[] multiverse_ids { get; set; }
        public int mtgo_id { get; set; }
        public int tcgplayer_id { get; set; }
        public int cardmarket_id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string lang { get; set; }
        public string released_at { get; set; }
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
        public string scryfall_uri { get; set; }
        public string layout { get; set; }
        public bool highres_image { get; set; }
        public string image_status { get; set; }
        public Image_Uris image_uris { get; set; }
        public string mana_cost { get; set; }
        public float cmc { get; set; }
        public string type_line { get; set; }
        public string oracle_text { get; set; }
        public string loyalty { get; set; }
        public string[] colors { get; set; }
        public string[] color_identity { get; set; }
        public string[] keywords { get; set; }
        public string[] produced_mana { get; set; }
        public All_Parts[] all_parts { get; set; }
        public Legalities legalities { get; set; }
        public string[] games { get; set; }
        public bool reserved { get; set; }
        public bool foil { get; set; }
        public bool nonfoil { get; set; }
        public string[] finishes { get; set; }
        public bool oversized { get; set; }
        public bool promo { get; set; }
        public bool reprint { get; set; }
        public bool variation { get; set; }
        public string set_id { get; set; }
        public string set { get; set; }
        public string set_name { get; set; }
        public string set_type { get; set; }
        public string set_uri { get; set; }
        public string set_search_uri { get; set; }
        public string scryfall_set_uri { get; set; }
        public string rulings_uri { get; set; }
        public string prints_search_uri { get; set; }
        public string collector_number { get; set; }
        public bool digital { get; set; }
        public string rarity { get; set; }
        public string card_back_id { get; set; }
        public string artist { get; set; }
        public string[] artist_ids { get; set; }
        public string illustration_id { get; set; }
        public string border_color { get; set; }
        public string frame { get; set; }
        public string security_stamp { get; set; }
        public bool full_art { get; set; }
        public bool textless { get; set; }
        public bool booster { get; set; }
        public bool story_spotlight { get; set; }
        public int edhrec_rank { get; set; }
        public Preview preview { get; set; }
        public Prices prices { get; set; }
        public Related_Uris related_uris { get; set; }
        public Purchase_Uris purchase_uris { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public int penny_rank { get; set; }
        public string flavor_text { get; set; }
        public string[] frame_effects { get; set; }
    }

    public class Image_Uris
    {
        public string small { get; set; }
        public string normal { get; set; }
        public string large { get; set; }
        public string png { get; set; }
        public string art_crop { get; set; }
        public string border_crop { get; set; }
    }

    public class Legalities
    {
        public string standard { get; set; }
        public string future { get; set; }
        public string historic { get; set; }
        public string gladiator { get; set; }
        public string pioneer { get; set; }
        public string explorer { get; set; }
        public string modern { get; set; }
        public string legacy { get; set; }
        public string pauper { get; set; }
        public string vintage { get; set; }
        public string penny { get; set; }
        public string commander { get; set; }
        public string brawl { get; set; }
        public string historicbrawl { get; set; }
        public string alchemy { get; set; }
        public string paupercommander { get; set; }
        public string duel { get; set; }
        public string oldschool { get; set; }
        public string premodern { get; set; }
    }

    public class Preview
    {
        public string source { get; set; }
        public string source_uri { get; set; }
        public string previewed_at { get; set; }
    }

    public class Prices
    {
        public string usd { get; set; }
        public string usd_foil { get; set; }
        public object usd_etched { get; set; }
        public string eur { get; set; }
        public string eur_foil { get; set; }
        public string tix { get; set; }
    }

    public class Related_Uris
    {
        public string gatherer { get; set; }
        public string tcgplayer_infinite_articles { get; set; }
        public string tcgplayer_infinite_decks { get; set; }
        public string edhrec { get; set; }
    }

    public class Purchase_Uris
    {
        public string tcgplayer { get; set; }
        public string cardmarket { get; set; }
        public string cardhoarder { get; set; }
    }

    public class All_Parts
    {
        public string _object { get; set; }
        public string id { get; set; }
        public string component { get; set; }
        public string name { get; set; }
        public string type_line { get; set; }
        public string uri { get; set; }
    }


    public class SetObject
    {
        public string _object { get; set; }
        public string id { get; set; }
        public string code { get; set; }
        public string mtgo_code { get; set; }
        public string arena_code { get; set; }
        public int tcgplayer_id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string scryfall_uri { get; set; }
        public string search_uri { get; set; }
        public string released_at { get; set; }
        public string set_type { get; set; }
        public int card_count { get; set; }
        public bool digital { get; set; }
        public bool nonfoil_only { get; set; }
        public bool foil_only { get; set; }
        public string icon_svg_uri { get; set; }
    }

}
