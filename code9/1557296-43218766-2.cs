    sprint1 = Input.GetKeyDown(KeyCode.W);
    sprint2 = Input.GetKeyDown(KeyCode.LeftShift);
    
    if (sprint1 && sprint2 && Scoped)
         speed = 8;
    else if (sprint1
         || Input.GetKeyDown(KeyCode.A) 
         || Input.GetKeyDown(KeyCode.S) 
         || Input.GetKeyDown(KeyCode.D))
    	speed = 4;     
    else
        speed = 0; 
    
