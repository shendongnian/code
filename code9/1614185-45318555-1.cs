    public void Button_Click1()
    {
       // Only render objects in the first layer (Default layer)
            cam.cullingMask = 1 << 0;
    }
    ...
