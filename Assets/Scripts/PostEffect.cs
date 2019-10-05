using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffect : MonoBehaviour {
    public Material _material;
    // private float size;
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        // size = (Mathf.Max((Mathf.Sin(Time.time * 3.0f) * 1.08f), 1.0f) - 1.0f) * 0.1f;
        // size = (Mathf.Max((t - (int)t), 0.9f) - 0.9f) * 0.1f;

        // Debug.LogFormat("Size: {0}", size);
        _material.SetFloat("_Size", getsize(Time.time));

        Graphics.Blit(src, dest, _material);
    }

    private float getsize(float time) {
        float duration = 0.06f;
        float max = 0.01f;
        float interval = 5.0f;

        float time2 = time % interval;
        if (time2 > duration) {
            return 0.0f;
        }
        return Mathf.Sin(time2 * Mathf.PI / duration) * max;
    }
}
