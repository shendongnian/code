    #if UNITY_ANDROID
    private void Control_Input()
    {
        if (Input.GetTouch(0).position.x > Screen.width / 2.0f) //If touched right part of screen
        {
            _normalizedxspeed = 1;
            if (!_faceRight)
                Flip();
        }
        else if (Input.GetTouch(0).position.x < Screen.width / 2.0f) //If touched left part of screen
        {
            _normalizedxspeed = -1;
            if (_faceRight)
                Flip();
        }
        else
        {
            _normalizedxspeed = 0;
        }
        if (_control.Able_Skip && Input.GetKeyDown(KeyCode.Space))
        {
            _control.Skip();
        }
        if (Input.GetMouseButtonDown(0))
            ShootProjectile();
        if (Input.GetKey(KeyCode.F))
            ShootProjectile();
    }
    #else
    private void Control_Input()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _normalizedxspeed = 1;
            if (!_faceRight)
                Flip();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _normalizedxspeed = -1;
            if (_faceRight)
                Flip();
        }
        else
        {
            _normalizedxspeed = 0;
        }
        if (_control.Able_Skip && Input.GetKeyDown(KeyCode.Space))
        {
            _control.Skip();
        }
        if (Input.GetMouseButtonDown(0))
            ShootProjectile();
        if (Input.GetKey(KeyCode.F))
            ShootProjectile();
    }
    #endif
