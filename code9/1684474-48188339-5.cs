    if (pressingJumpButton && canJump)
    {
        if (!inAir)
        {
            Debug.Log("jump");
            inAir = true;
            DoJump();
        }
        else if (maxAir > 0)
        {
            Debug.Log("airJump");
            maxAir--;
            DoJump();
        }
    }
    private void DoJump()
    {
        GetComponent<Rigidbody>().velocity = 
            new Vector3(GetComponent<Rigidbody>().velocity.x, 
                        jumpingSpeed, 
                        GetComponent<Rigidbody>().velocity.z);
    }
