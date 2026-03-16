using Doll.Models.Powers.PowerModels;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace Doll.Models.Powers;

public sealed class FleshDetachedPower : DollPowerModel
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterCurrentHpChanged(Creature creature, decimal delta)
    {
        if (creature == Owner && delta > 0)
            await CreatureCmd.GainBlock(Owner, Amount, ValueProp.Unpowered, null);
    }
}