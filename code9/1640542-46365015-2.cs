    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(checkedObject.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
        }
    }
