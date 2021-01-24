    float JumpTime;
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
           JumpTime = 0;
        }
        if (Input.GetButton("Jump"))
        {
            JumpTime = JumpTime + Time.deltaTime; 
        }
        else if (Input.GetButtonUp("Jump") && JumpTime < 0.3f)
        {
            playerCtrl.ActionShortJump();
        }
        else if (Input.GetButtonUp("Jump") && JumpTime > 0.3f)
        {
            playerCtrl.ActionJump();
        }
    }
