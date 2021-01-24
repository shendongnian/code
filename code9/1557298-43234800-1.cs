        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Scoped)
            speed = 8;
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            speed = 4;
        else
            speed = 0;
 
