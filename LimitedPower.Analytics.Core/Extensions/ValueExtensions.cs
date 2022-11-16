using System.Globalization;

namespace LimitedPower.Analytics.Core.Extensions
{
    public static class ValueExtensions
    {
        public static string PercentDisplay(this float? percent) =>
            percent == null ? string.Empty : ((float)percent).PercentDisplay();

        public static string PercentDisplay(this float percent)
        {
            var p2 = Convert.ToDouble(percent);
            return Math.Round(p2 * 100, 2).ToString(CultureInfo.InvariantCulture);
        }

        public static string PointDisplay(this float? points) =>
            points == null ? string.Empty : ((float)points).PointDisplay();

        public static string PointDisplay(this float points)
        {
            var p2 = Convert.ToDouble(points);
            return Math.Round(p2 * 100, 2).ToString(CultureInfo.InvariantCulture);
        }

        public static string FloatRound(this float nr)
        {
            return Math.Round(nr, 2).ToString(CultureInfo.InvariantCulture);
        }

    }
}
