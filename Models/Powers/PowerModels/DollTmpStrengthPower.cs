using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Doll.Models.Powers.PowerModels;

public abstract class DollTmpStrengthPower : TemporaryStrengthPower, ICustomPowerModel
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
}
