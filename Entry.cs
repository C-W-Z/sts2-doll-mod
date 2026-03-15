using Godot.Bridge;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace Doll;

// 必须要加的属性，用于注册 Mod。字符串和初始化函数命名一致。
[ModInitializer(nameof(Initialize))]
public class Entry
{
    private const string ModId = "Doll"; // At the moment, this is used only for the Logger and harmony names.
    public static Logger Logger { get; } = new(ModId, LogType.Generic);

    // 打 patch（即修改游戏代码的功能）用
    private static Harmony? _harmony;

    // 初始化函数
    public static void Initialize()
    {
        ScriptManagerBridge.LookupScriptsInAssembly(typeof(Entry).Assembly);
        // 传入参数随意，只要不和其他人撞车即可
        _harmony = new Harmony(ModId);
        _harmony.PatchAll();
    }
}
