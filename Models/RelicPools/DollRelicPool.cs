using BaseLib.Abstracts;
using Doll.Models.Relics;
using MegaCrit.Sts2.Core.Models;

namespace Doll.Models.RelicPools;

public sealed class DollRelicPool : CustomRelicPoolModel
{
    // 能量图标。
    public override string EnergyColorName => "ironclad";

    protected override IEnumerable<RelicModel> GenerateAllRelics()
    {
        return [
            ModelDb.Relic<SilverTech>()
        ];
    }
}