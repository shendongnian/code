    sprint1 = Input.GetKeyDown(KeyCode.W);
    sprint2 = Input.GetKeyDown(KeyCode.LeftShift);
    
    if (sprint2)
    {
       if (sprint1 && Scoped)
    		speed = 8;
         else
            speed = 4; // do you want speed 0 or 4 if either of these others are false
    }
    else
    {
        if (sprint1
         || Input.GetKeyDown(KeyCode.A) 
         || Input.GetKeyDown(KeyCode.S) 
         || Input.GetKeyDown(KeyCode.D))
    		speed = 4;     
        else
            speed = 0; 
    }
