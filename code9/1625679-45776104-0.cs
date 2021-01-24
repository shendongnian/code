    bool rotate = false;
    
    void startRotating()
    {
        rotate = true;
    }
    
    void stopRotating()
    {
        rotate = false;
    }
    
    void Update()
    {
        if (rotate)
            transform.Rotate(10f, 50f, 10f);
    }
