    TypeOfGame game = null; // declare local variable here
    // note that you should provide initial value as well
    
    try
    {
       // assigne it here
       game = api.GetCurrentGame(RiotSharp.Platform.EUW1, 79200188);
    }
    catch (RiotSharpException ex)
    {
        // I hope you have some real code here
        throw;
    }
    
    // now you can use it 
    foreach(var player in game.Participants)
    {
    }
