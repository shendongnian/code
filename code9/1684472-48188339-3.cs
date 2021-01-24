    if (pressingJumpButton && canJump)
    {
        if (!inAir)
        {
            Debug.Log("jump");
            inAir = true;
        }
        else
        {
            Debug.Log("airJump");
            maxAir--;
        }
        GetComponent<Rigidbody>().velocity = 
            new Vector3(GetComponent<Rigidbody>().velocity.x, 
                        jumpingSpeed, 
                        GetComponent<Rigidbody>().velocity.z);
    }
