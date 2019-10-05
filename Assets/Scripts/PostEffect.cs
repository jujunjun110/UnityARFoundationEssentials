using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffect : MonoBehaviour {
    public Material _material;
    private float size;
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        size = Mathf.Sin(Time.time) * 0.5f + 0.5f;
        Debug.LogFormat("Size: {0}", size);
        _material.SetFloat("_Size", size);

        Graphics.Blit(src, dest, _material);
    }
}
