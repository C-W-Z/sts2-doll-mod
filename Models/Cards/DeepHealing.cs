using Doll.Models.Cards.CardModels;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace Doll.Models.Cards;

// TODO: TargetType.AnyAlly只能選擇其他玩家，AnyPlayer只能選擇玩家，需要自己創建一種新的TargetType可以選擇召喚物
public sealed class DeepHealing() : DollCardModel(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyPlayer)
{
    public override CardMultiplayerConstraint MultiplayerConstraint => CardMultiplayerConstraint.None;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new HealVar(7m)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await CreatureCmd.Heal(cardPlay.Target, DynamicVars.Heal.BaseValue, true);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Heal.UpgradeValueBy(3m);
    }
}