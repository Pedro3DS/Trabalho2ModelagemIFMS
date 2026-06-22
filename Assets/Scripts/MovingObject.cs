using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [Header("Floating")]
    [SerializeField] private bool floatObject = true;
    [SerializeField] private float floatHeight = 0.5f;
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private bool startGoingDown;

    [Header("Rotation")]
    [SerializeField] private bool rotateObject = true;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 90, 0);

    private Vector3 startPosition;
    private float offset;

    private void Start()
    {
        startPosition = transform.position;

        if (startGoingDown)
            offset = Mathf.PI;
    }

    private void Update()
    {
        if (floatObject)
        {
            float y = Mathf.Sin(Time.time * floatSpeed + offset) * floatHeight;

            transform.position = new Vector3(
                startPosition.x,
                startPosition.y + y,
                startPosition.z
            );
        }

        if (rotateObject)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
