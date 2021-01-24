    int speed = 7;
    
    float counter = 0;
    void Update()
    {
        //Increment Counter
        counter += Time.deltaTime;
    
        if (counter >= 30)
        {
            //Increment Speed by 4
            incrementSpeed();
    
            //RESET Counter
            counter = 0;
        }
    }
    
    
    void incrementSpeed()
    {
        speed += 4;
    }
