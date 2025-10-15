using HarmonyLib;
using HKSS.ShowHitbox.Behaviour;

namespace HKSS.ShowHitbox.Patches;

[HarmonyPatch(typeof(DebugDrawColliderRuntime))]
internal class DebugDrawColliderRuntimePatches
{
    [HarmonyPatch(nameof(Init))]
    [HarmonyPrefix]
    private static void Init(DebugDrawColliderRuntime __instance)
    {
        if (__instance.isInitialized) return;
        var moreInfosController = __instance.TryGetComponent<MoreInfosController>(out var component)
            ? component
            : __instance.gameObject.AddComponent<MoreInfosController>();
        if (!moreInfosController) return;
        moreInfosController.DebugDrawColliderRuntime = __instance;
    }
}