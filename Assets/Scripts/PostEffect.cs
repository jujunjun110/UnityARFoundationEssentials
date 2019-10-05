using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class PostEffect : MonoBehaviour {
    public Material _material;
    [SerializeField] float duration = 0.06f;
    [SerializeField] float max = 0.01f;
    [SerializeField] float basement = 0.003f;
    [SerializeField] float interval = 5.0f;
    // private float size;
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        _material.SetFloat("_Size", getsize(Time.time));
        Graphics.Blit(src, dest, _material);
    }

    private float getsize(float time) {
        float time2 = time % interval;
        if (time2 > duration) {
            return basement;
        }
        return Mathf.Sin(time2 * Mathf.PI / duration) * max;
    }
}
