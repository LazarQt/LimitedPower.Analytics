using System.Text.RegularExpressions;
using LimitedPower.Analytics.Models;
using Group = LimitedPower.Analytics.Models.Group;

namespace LimitedPower.Analytics.Core.Extensions
{
    public static class LimitedEventExtensions
    {
        public static Group GetMainDeck(this LimitedEvent limitedEvent)
        {
            return limitedEvent.Groups.First(e => e.Name == Const.LimitedEvent.MainDeck);
        }
    }
}
