using BaseLib.Abstracts;
using Godot;

namespace Doll.Models.Powers.PowerModels;

public abstract class DollPowerModel : CustomPowerModel
{
    public override string? CustomPackedIconPath
    {
        get
        {
            var path = $"res://images/powers/{Id.Entry.ToLowerInvariant()}.png";
            if (!ResourceLoader.Exists(path))
                return $"res://images/missing.png";
            return path;
        }
    }

    public override string? CustomBigIconPath
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
