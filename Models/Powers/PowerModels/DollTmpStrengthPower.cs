using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Doll.Models.Powers.PowerModels;

public abstract class DollTmpStrengthPower : TemporaryStrengthPower
{
	public virtual string? CustomPackedIconPath
    {
        get
        {
            var path = $"res://images/powers/{Id.Entry.ToLowerInvariant()}.png";
            if (!ResourceLoader.Exists(path))
                return $"res://images/missing.png";
            return path;
        }
    }

    public virtual string? CustomBigIconPath
    {
        get
        {
            var path = $"res://images/powers/{Id.Entry.ToLowerInvariant()}.png";
            if (!ResourceLoader.Exists(path))
                return $"res://images/missing.png";
            return path;
        }
    }

    public virtual string? CustomBigBetaIconPath => null;
}

[HarmonyPatch(typeof(PowerModel), "PackedIconPath", MethodType.Getter)]
class PackedIconPath
{
    [HarmonyPrefix]
    static bool Custom(PowerModel __instance, ref string? __result)
    {
        if (__instance is not DollTmpStrengthPower customPower)
            return true;

        __result = customPower.CustomPackedIconPath;
        return __result == null;
    }
}

[HarmonyPatch(typeof(PowerModel), "BigIconPath", MethodType.Getter)]
class BigIconPath
{
    [HarmonyPrefix]
    static bool Custom(PowerModel __instance, ref string? __result)
    {
        if (__instance is not DollTmpStrengthPower customPower)
            return true;

        __result = customPower.CustomBigIconPath;
        return __result == null;
    }
}

[HarmonyPatch(typeof(PowerModel), "BigBetaIconPath", MethodType.Getter)]
class BigBetaIconPath
{
    [HarmonyPrefix]
    static bool Custom(PowerModel __instance, ref string? __result)
    {
        if (__instance is not DollTmpStrengthPower customPower)
            return true;

        __result = customPower.CustomBigBetaIconPath;
        return __result == null;
    }
}
