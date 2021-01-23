    public static bool IsStartedFirstTime = false;
    
    public void ButtonNewGame()
    {
        if(IsStartedFirstTime == false) // if the game was started once
        {
            IsStartedFirstTime = true;
            //Logic on first time run 
        }
        if(IsStartedFirstTime)
            // your logic that happens if it is already started      
    }
