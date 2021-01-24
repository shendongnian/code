    public float speed = 1.0f;
    Vector3 angle;
    float rotation = 0f;
    void Start()
    {
        angle = transform.localEulerAngles;
    }
    void Update() {
        rotation += speed * Time.deltaTime;
        if (rotation >= 360f) // Not sure if you need to constrain the angle.
            rotation -= 360f; // but this will keep it to a value of 0 to 359.99...
        transform.localEulerAngles = new Vector3(angle.x, rotation, angle.z);
    }
