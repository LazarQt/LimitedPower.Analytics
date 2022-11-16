// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
namespace LimitedPower.Analytics.Models
{
    public enum DraftType
    {
        PremierDraft,
        TradDraft,
        Sealed,
        TradSealed
    }

    public enum Set
    {
        DMU,
        BRO
    }

    public enum DataTimespan
    {
        Recent,
        All
    }

    public enum ColorCombination
    {
        None,
        W,
        U,
        B,
        R,
        G,
        WU,
        WB,
        WR,
        WG,
        UB,
        UR,
        UG,
        BR,
        BG,
        RG,
        WUB,
        WUR,
        WUG,
        WBR,
        WBG,
        WRG,
        UBR,
        UBG,
        URG,
        BRG,
        // ReSharper disable UnusedMember.Global
        WUBR,
        WUBG,
        WURG,
        WBRG,
        UBRG,
        WUBRG
        // ReSharper restore UnusedMember.Global
    }
}