    public static bool IsStartedFirstTime = false;
    
    public void ButtonNewGame()
    {
        if(IsStartedFirstTime == false) // if the game was started once
            IsStartedFirstTime = true;
        if(IsStartedFirstTime)
            // your logic here      
    }
