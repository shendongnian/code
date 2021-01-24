    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        //Mobile Devices
        #if UNITY_IOS || UNITY_ANDROID || UNITY_WSA_10_0 
        movement = new Vector3(-Input.acceleration.y, 0.0f, Input.acceleration.x);
        #else
        //Desktop 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        #endif
        rb.AddForce(movement * speed);
    }
