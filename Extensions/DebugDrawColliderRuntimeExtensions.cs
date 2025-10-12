using BepInExUtils.Attributes;
using JetBrains.Annotations;

namespace HKSS.ShowHitbox.Extensions;

[AccessExtensions]
[AccessInstance<DebugDrawColliderRuntime>]
[AccessField<bool>("isInitialized")]
[AccessField<DebugDrawColliderRuntime.ColorType>("type")]
[UsedImplicitly]
public static partial class DebugDrawColliderRuntimeExtensions
{
}