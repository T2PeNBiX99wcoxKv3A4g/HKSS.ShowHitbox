using UnityEngine;

namespace HKSS.ShowHitbox.Behaviour;

public class MoreInfosController : MonoBehaviour
{
    internal DebugDrawColliderRuntime? DebugDrawColliderRuntime;
    private const float Width = 200f;
    private const float Height = 200f;

    private void OnGUI()
    {
        if (!Configs.ShowHitbox || !Configs.MoreInfos) return;
        var cam = GameCameras.instance.mainCamera;
        if (!cam) return;
        var objScreenPos = cam.WorldToScreenPoint(transform.position);
        SetGUIColour();
        GUI.Label(new(objScreenPos.x - Width / 2, Screen.height - (objScreenPos.y - Height / 2), Width, Height),
            gameObject.FullName());
    }

    private void SetGUIColour()
    {
        if (!DebugDrawColliderRuntime) return;
        GUI.color = DebugDrawColliderRuntime.type switch
        {
            DebugDrawColliderRuntime.ColorType.Tilemap => new(0.0f, 0.44f, 0.0f),
            DebugDrawColliderRuntime.ColorType.TerrainCollider => Color.green,
            DebugDrawColliderRuntime.ColorType.Danger => Color.red,
            DebugDrawColliderRuntime.ColorType.Roof => new(0.8f, 1f, 0.0f),
            DebugDrawColliderRuntime.ColorType.Region => new(0.4f, 0.75f, 1f),
            DebugDrawColliderRuntime.ColorType.Enemy => new(1f, 0.7f, 0.0f),
            DebugDrawColliderRuntime.ColorType.Water => new(0.2f, 0.5f, 1f),
            DebugDrawColliderRuntime.ColorType.TransitionPoint => Color.magenta,
            DebugDrawColliderRuntime.ColorType.SandRegion => new(1f, 0.7f, 0.7f),
            DebugDrawColliderRuntime.ColorType.ShardRegion => Color.grey,
            DebugDrawColliderRuntime.ColorType.CameraLock => new(0.16f, 0.17f, 0.28f),
            _ => Color.white
        };
    }
}