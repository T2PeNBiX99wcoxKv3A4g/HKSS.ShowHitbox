using BepInEx;
using BepInExUtils.Attributes;
using UnityEngine;

namespace HKSS.ShowHitbox;

[BepInUtils("io.github.ykysnk.HKSS.ShowHitbox", "Show Hitbox", Version)]
[BepInProcess(Utils.GameName)]
[ConfigBind<KeyCode>("ToggleKey", SectionOptions, KeyCode.F11, "The toggle key to toggle the hitbox display.")]
[ConfigBind<bool>("ShowHitbox", SectionOptions, false, "Show the hitbox.")]
public partial class Main
{
    private const string SectionOptions = "Options";
    private const string Version = "0.1.0";

    private void Update()
    {
        if (!UnityInput.Current.GetKeyDown(Configs.ToggleKey)) return;
        Configs.ShowHitbox = !Configs.ShowHitbox;
    }

    protected override void PostAwake()
    {
        Configs.OnShowHitboxValueChanged += OnToggleHitbox;
        DebugDrawColliderRuntime.IsShowing = Configs.ShowHitbox;
    }

    private static void OnToggleHitbox(bool oldValue, bool newValue)
    {
        Utils.Logger.Info($"Debug hitbox is now turn {(newValue ? "on" : "off")}!");
        DebugDrawColliderRuntime.IsShowing = newValue;
    }
}