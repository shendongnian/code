    public static bool IsStartedFirstTime = false;
    
    public void ButtonNewGame()
    {
        if(IsStartedFirstTime == false) // if the game was started once
        {
            IsStartedFirstTime = true;
            //Logic on first time run 
            //return;  //depending on your intent, you might wish to return or not!
        }
        if(IsStartedFirstTime)
            // your logic that happens if it is already started      
    }
