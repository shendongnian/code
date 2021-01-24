    UnityEngine.Camera cam;
    bool isMoving;
    void Start()
    {
        cam = UnityEngine.Camera.main;
        isMoving = true;
    }
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(checkedObject.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            isMoving = false;
        }
        else
            isMoving = true;
        if(isMoving)
            Move();
    }
