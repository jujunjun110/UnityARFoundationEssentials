using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffect : MonoBehaviour {
    public Material _material;
    private float size;
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        // size = (Mathf.Max((Mathf.Sin(Time.time * 3.0f) * 1.08f), 1.0f) - 1.0f) * 0.1f;
        float t = Time.time;

        size = (Mathf.Max((t - (int)t), 0.9f) - 0.9f) * 0.1f;

        // Debug.LogFormat("Size: {0}", size);
        _material.SetFloat("_Size", size);

        Graphics.Blit(src, dest, _material);
    }
}
