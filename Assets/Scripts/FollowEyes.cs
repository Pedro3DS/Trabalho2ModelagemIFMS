using UnityEngine;

public class FollowEyes : MonoBehaviour
{
    [Header("Material")]
    [SerializeField] private Renderer targetRenderer;

    [SerializeField] private float horizontalRange = 0.03f;
    [SerializeField] private float verticalRange = 0.01f;

    [SerializeField] private float speed = 1f;

    private Material materialInstance;

    private void Start()
    {
        materialInstance = targetRenderer.material;
    }

    private void Update()
    {
        float x = Mathf.Cos(Time.time * speed) * horizontalRange;
        float y = Mathf.Sin(Time.time * speed) * verticalRange;

        materialInstance.mainTextureOffset = new Vector2(x, y);
    }
}
