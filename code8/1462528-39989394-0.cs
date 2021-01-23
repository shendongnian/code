     Game game = new Game(Mock);
     public void Go()
      {
        MockFiler Mock = new MockFiler("###\n# #\n#@#\n###");       
        game.Load("h:\theFileNameDoesNotMatterAsItReturnsAString");
        string Level = game.Level;
        View.ShowGame(Level); 
    }    
    public void PassMove(Direction Direction) 
    {
        game.Move(Direction);  
        string Level = game.Level;
        View.ShowGame(Level);
    }
