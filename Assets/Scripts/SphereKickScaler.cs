using UnityEngine;

public class SphereKickScaler : MonoBehaviour
{
    [Header("Scale Range")]
    public float minScale = 1f;
    public float maxScale = 2f;

    [Header("Input")]
    [Range(0f, 1f)] public float kickValue = 0f;

    [Header("Smoothing")]
    public bool smooth = true;
    public float smoothSpeed = 12f;

    private float currentScale;

    void Start()
    {
        currentScale = minScale;
        ApplyScale(currentScale);
    }

    void Update()
    {
        float targetScale = Mathf.Lerp(minScale, maxScale, Mathf.Clamp01(kickValue));

        if (smooth)
            currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * smoothSpeed);
        else
            currentScale = targetScale;

        ApplyScale(currentScale);
    }

    void ApplyScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    // call this from OSC
    public void SetKick(float value)
    {
        kickValue = Mathf.Clamp01(value);
    }
}