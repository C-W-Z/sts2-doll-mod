using Doll.Models.Cards.CardModels;
using Doll.Models.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Doll.Models.Cards;

public sealed class TheFiveDecay() : DollCardModel(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Ethereal, CardKeyword.Exhaust];

    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new DynamicVar("Power", 1m),
        new DynamicVar("StrengthLoss", 1m),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target);
        await CreatureCmd.TriggerAnim(Owner.Creature, "Cast", Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<VulnerablePower>(cardPlay.Target, DynamicVars["Power"].BaseValue, Owner.Creature, this);
        await PowerCmd.Apply<WeakPower>(cardPlay.Target, DynamicVars["Power"].BaseValue, Owner.Creature, this);
        await PowerCmd.Apply<FrailPower>(cardPlay.Target, DynamicVars["Power"].BaseValue, Owner.Creature, this);
        await PowerCmd.Apply<TheFiveDecayPower>(cardPlay.Target, DynamicVars["StrengthLoss"].BaseValue, Owner.Creature, this);
        // TODO: Apply 重創
    }

    protected override void OnUpgrade()
    {
        RemoveKeyword(CardKeyword.Ethereal);
    }
}