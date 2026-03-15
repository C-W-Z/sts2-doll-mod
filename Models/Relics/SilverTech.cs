
using BaseLib.Abstracts;
using BaseLib.Utils;
using Doll.Models.RelicPools;
using MegaCrit.Sts2.Core.Entities.Relics;

namespace Doll.Models.Relics;

[Pool(typeof(DollRelicPool))]
public sealed class SilverTech : CustomRelicModel
{
    // private bool _usedThisCombat;

    public override RelicRarity Rarity => RelicRarity.Starter;

    // protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<StrengthPower>(2M)];

    // protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<StrengthPower>()];

    // public override async Task AfterDamageReceived(
    //     PlayerChoiceContext choiceContext,
    //     Creature target,
    //     DamageResult result,
    //     ValueProp props,
    //     Creature? dealer,
    //     CardModel? cardSource)
    // {
    // }

    // public override Task AfterTurnEnd(PlayerChoiceContext choiceContext, CombatSide side)
    // {
    //     return Task.CompletedTask;
    // }
}