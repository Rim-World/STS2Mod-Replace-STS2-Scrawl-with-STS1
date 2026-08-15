using HarmonyLib;
using MegaCrit.Sts2.Core.Models.Cards;

namespace ScrawlReplacementMod.Patches;

[HarmonyPatch(typeof(Scrawl), "OnUpgrade")]
public static class ScrawlOnUpgradePatch
{
    private static bool Prefix(Scrawl __instance)
    {
        if (!ModConfig.IsReplaceEnabled)
        {
            return true;
        }

        __instance.EnergyCost.UpgradeBy(-1);
        return false;
    }
}