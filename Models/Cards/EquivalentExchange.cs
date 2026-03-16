using Doll.Models.Cards.CardModels;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Doll.Models.Cards;

public sealed class EquivalentExchange() : DollCardModel(3, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new HealVar(5m),
        new CalculationBaseVar(0m),
        new CalculationExtraVar(2m),
        new CalculatedBlockVar(ValueProp.Move).WithMultiplier((card, _) => PileType.Hand.GetPile(card.Owner).Cards.Count)
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        var blockAmount = DynamicVars.CalculatedBlock.Calculate(cardPlay.Target);
        IEnumerable<CardModel> cards = PileType.Hand.GetPile(Owner).Cards;
        await CardCmd.Discard(choiceContext, cards);
        await CreatureCmd.Heal(Owner.Creature, DynamicVars.Heal.BaseValue + blockAmount, true);
        await CreatureCmd.GainBlock(Owner.Creature, blockAmount, DynamicVars.CalculatedBlock.Props, cardPlay);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationExtra.UpgradeValueBy(1m);
    }
}