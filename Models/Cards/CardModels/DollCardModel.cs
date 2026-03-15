using BaseLib.Abstracts;
using BaseLib.Utils;
using Doll.Models.CardPools;
using Godot;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Doll.Models.Cards.CardModels;

[Pool(typeof(DollCardPool))]
public abstract class DollCardModel(int baseCost, CardType type, CardRarity rarity, TargetType target, bool showInCardLibrary = true, bool autoAdd = true) : CustomCardModel(baseCost, type, rarity, target, showInCardLibrary, autoAdd)
{
    public override string PortraitPath
    {
        get
        {
            var path = $"res://images/cards/{Pool.Title.ToLowerInvariant()}/{Id.Entry.ToLowerInvariant()}.png";
            if (!ResourceLoader.Exists(path))
                return $"res://images/cards/missing.png";
            return path;
        }
    }
}
