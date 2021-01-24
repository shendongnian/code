    public class PlayerController : MonoBehaviour
    {
    float RotateX;
    float RotateY;
    public GameObject Camera;
    public float RotationSpeed = 3.0f;
    public float MaxYAxis = 60.0f;
    public float MinYAxis = -48.0f;
    private void Start()
    {
    }
    void Update()
    {
        Rotation();
    }
    void Rotation()
    {
        RotateX += Input.GetAxis("Mouse X") * RotationSpeed;
        RotateY += Input.GetAxis("Mouse Y") * RotationSpeed;
        RotateY = Mathf.Clamp(RotateY, MinYAxis, MaxYAxis);
        Camera.transform.localRotation = Quaternion.Euler(-RotateY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, RotateX, 0f);
    }
    }
