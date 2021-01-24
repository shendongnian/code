        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift) && Scoped)
                speed = 8;
            else
                speed = 4;
        }
        else
            speed = 0;
 
