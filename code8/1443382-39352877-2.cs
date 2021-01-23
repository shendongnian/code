    Resolution defaultRes;
    void Start()
    {
        defaultRes = Screen.currentResolution;
    }
    bool fullScreen = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            fullScreen = !fullScreen;
            if (fullScreen)
            {
                Screen.SetResolution(defaultRes.width, defaultRes.height, true);
            }
            else
            {
                Screen.SetResolution(640, 480, true);
            }
        }
    }
