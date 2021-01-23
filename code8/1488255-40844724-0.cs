    void Start()
    {
        Camera camera2 = GameObject.Find("Cam2").GetComponent<Camera>();
        camera2.targetDisplay = 1;
        Display.displays[1].Activate();
    }
