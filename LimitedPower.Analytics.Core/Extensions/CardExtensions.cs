using System.Globalization;
using System.Text.RegularExpressions;

namespace LimitedPower.Analytics.Core.Extensions
{
    public static class CardExtensions
    {
        public static string ImageName(this string input) => $"{input.CardCompareName()}.jpg";

        public static string CardCompareName(this string originalCardName) =>
            new Regex("[^a-zA-Z0-9-]").Replace(originalCardName, string.Empty).ToLower();

        public static bool IsSameCard(this string card1, string card2) => card1 == card2;
        //public static bool IsSameCard(this string card1, string card2) => card1.CardCompareName() == card2.CardCompareName();

        public static string ManaCastColors(this string str) =>
            string.IsNullOrEmpty(str) ? string.Empty : new Regex("[^wubrgWUBRG]").Replace(str, "");

        public static string ManaCastColorsWithoutSplash(this string str) =>
            string.IsNullOrEmpty(str) ? string.Empty : new Regex("[^WUBRG]").Replace(str, "");
    }
}
