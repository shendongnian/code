    public Camera leftCamera;
    public Camera rightCamera;
    
    mainCameraBackground = new Color (1, 0.8f, 0); // set to yellow initially
    mainCameraFaded = new Color(1f,1f,1f);
    mainCameraCurrent = new Color (0f, 0f, 0f);
    
    // main camera is converted to left + right by Google VR SDK.
    // this is why we need to handle both separately
    
    leftCamera.clearFlags = CameraClearFlags.SolidColor;
    leftCamera.backgroundColor = mainCameraBackground;
    
    rightCamera.clearFlags = CameraClearFlags.SolidColor;
    rightCamera.backgroundColor = mainCameraBackground;
