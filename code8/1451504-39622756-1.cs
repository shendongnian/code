    Camera[] myCams = new Camera[4];
    void Start()
    {
        //Get Main Camera
        myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Find All other Cameras
        myCams[1] = GameObject.Find("Camera2").GetComponent<Camera>();
        myCams[2] = GameObject.Find("Camera3").GetComponent<Camera>();
        myCams[3] = GameObject.Find("Camera4").GetComponent<Camera>();
        //Call function when when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;
        //Map each Camera to a Display
        mapCameraToDisplay();
    }
    void mapCameraToDisplay()
    {
        //Loop over Connected Displays
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }
    }
    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }
