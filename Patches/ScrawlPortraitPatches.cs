using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace ScrawlReplacementMod.Patches;

[HarmonyPatch(typeof(CardModel), "PortraitPngPath", MethodType.Getter)]
public static class ScrawlPortraitPngPathPatch
{
    private static bool Prefix(CardModel __instance, ref string __result)
    {
        if (__instance is not Scrawl || !ModConfig.IsReplaceEnabled)
        {
            return true;
        }

        __result = ModEntry.PortraitPng;
        return false;
    }
}

[HarmonyPatch(typeof(CardModel), "Portrait", MethodType.Getter)]
public static class ScrawlPortraitPatch
{
    private static bool Prefix(CardModel __instance, ref Texture2D __result)
    {
        if (__instance is not Scrawl || !ModConfig.IsReplaceEnabled)
        {
            return true;
        }

        __result = PortraitTextureLoader.Get();
        return false;
    }
}

[HarmonyPatch(typeof(CardModel), "PortraitPath", MethodType.Getter)]
public static class ScrawlPortraitPathPatch
{
    private static bool Prefix(CardModel __instance, ref string __result)
    {
        if (__instance is not Scrawl || !ModConfig.IsReplaceEnabled)
        {
            return true;
        }

        __result = ModEntry.PortraitPng;
        return false;
    }
}