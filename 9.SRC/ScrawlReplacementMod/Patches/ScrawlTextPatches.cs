using HarmonyLib;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace ScrawlReplacementMod.Patches;

[HarmonyPatch(typeof(CardModel), "TitleLocString", MethodType.Getter)]
public static class ScrawlTitleLocStringPatch
{
    private static void Postfix(CardModel __instance, ref LocString __result)
    {
        if (__instance is Scrawl && ModConfig.IsReplaceEnabled)
        {
            __result = new LocString("cards", "RE_SCRAWL.title");
        }
    }
}

[HarmonyPatch(typeof(CardModel), "Description", MethodType.Getter)]
public static class ScrawlDescriptionPatch
{
    private static void Postfix(CardModel __instance, ref LocString __result)
    {
        if (__instance is Scrawl && ModConfig.IsReplaceEnabled)
        {
            __result = new LocString("cards", "RE_SCRAWL.description");
        }
    }
}