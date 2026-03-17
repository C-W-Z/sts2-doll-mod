using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;

namespace Doll.Patches;

/// <summary>
/// If player apply debuff to self or ally before turn ends (not from curse cards like doubt), it should tick at enemy turn ends
/// </summary>
[HarmonyPatch(typeof(PowerCmd), nameof(PowerCmd.Apply), [typeof(PowerModel), typeof(Creature), typeof(decimal), typeof(Creature), typeof(CardModel), typeof(bool)])]
public static class SelfApplyDebuffPatch
{
    [HarmonyPostfix]
    static void Postfix(ref Task __result, PowerModel power, Creature target)
    {
        // 將原本的 Task 替換為我們包裝過的 Task
        __result = WrappedApplyTask(__result, power, target);
    }

    static async Task WrappedApplyTask(Task originalTask, PowerModel power, Creature target)
    {
        // 1. 重要：先等待原函式內所有的 await（包括 Hook.AfterPowerAmountChanged 等）全部執行完畢
        await originalTask;

        Entry.Logger.Info($"Postfix: apply power {power.Id.Entry}; target.IsPlayer == {target.IsPlayer}; power.Applier?.Side == {power.Applier?.Side}");

        // 2. 此時原函式的所有邏輯已跑完，包含它把 SkipNextDurationTick 設為 true 的部分
        // 我們在這裡執行你的自定義邏輯
        if (target.Side == CombatSide.Player && power.Type == PowerType.Debuff && power.Applier?.Side == CombatSide.Player)
        {
            Entry.Logger.Info($"Origin SkipNextDurationTick: {power.SkipNextDurationTick}");

            // 強制修正回 false
            power.SkipNextDurationTick = false;

            Entry.Logger.Info($"SkipNextDurationTick become: {power.SkipNextDurationTick}");
        }
    }
}