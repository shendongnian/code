    void Update()
    {
        checkTouchOnScreen();
    }
    
    void checkTouchOnScreen()
    {
        #if UNITY_IOS || UNITY_ANDROID || UNITY_TVOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Make sure finger is NOT over a UI element
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                OnSCreenTouched();
            }
        }
        #else
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Make sure finger is NOT over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnSCreenTouched();
            }
        }
        #endif
    }
    
    
    void OnSCreenTouched()
    {
        Debug.Log("Touched on the Screen where there is no UI");
        //Rotate/Pan/Zoom the camera here
    }
