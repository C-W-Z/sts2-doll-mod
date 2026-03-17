using BaseLib.Abstracts;
using Doll.Models.Powers.PowerModels;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Runs;

namespace Doll.Models.Powers;

public sealed class BlightenPower : DollPowerModel, IHealAmountModifier
{
    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;

    // public decimal ModifyHealAdditive(Creature creature, decimal amount)
    // {
    //     if (creature != Owner)
    //         return 0m;
    //     return 4m;
    // }

    public decimal ModifyHealMultiplicative(Creature creature, decimal amount)
    {
        if (creature != Owner)
            return 1m;
        return 0.75m;
    }

    public override async Task AfterTurnEnd(PlayerChoiceContext choiceContext, CombatSide side)
    {
        if (side == CombatSide.Enemy)
        {
            await PowerCmd.TickDownDuration(this);
        }
    }
}
