    int collisonCounter = 0;
    
    void OnCollisionEnter(Collision collision)
    {
        //Increment Collison
        collisonCounter++;
    
        if (collisonCounter == 2)
        {
            //reduce the life by 50 percent
    
        }
    
        if (collisonCounter == 3)
        {
            // kill the enemy
    
    
            //Reset counter
            collisonCounter = 0;
        }
    }
