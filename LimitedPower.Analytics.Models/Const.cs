using System.Security.Cryptography.X509Certificates;

namespace LimitedPower.Analytics.Models
{
    public static class Const
    {
        public static string DateFormat = "yyyy-MM-dd";
        public static int RecentDays = -14;
        public static string SeventeenLandsBaseUrl = "https://www.17lands.com";
        public static int RemoteGraceTime = 5500;

        public static class Db
        {
            public static string CardRatingsTable = "cardratings";
            public static string TrophyDecks = "trophydecks";
            public static string LimitedEvents = "limitedevents";
        }

        public static class LimitedEvent
        {
            public static string MainDeck = "Maindeck";
        }
    }
}
