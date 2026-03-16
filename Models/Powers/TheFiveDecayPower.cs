using Doll.Models.Cards;
using Doll.Models.Powers.PowerModels;
using MegaCrit.Sts2.Core.Models;

namespace Doll.Models.Powers;

public class TheFiveDecayPower : DollTmpStrengthPower
{
	public override AbstractModel OriginModel => ModelDb.Card<TheFiveDecay>();

	protected override bool IsPositive => false;
}
