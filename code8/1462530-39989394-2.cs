     //Creating instance and passing 
     MockFiler Mock = new MockFiler("###\n# #\n#@#\n###"); 
     //Creating instance  for Game
     Game game = new Game(Mock);
     //Now these can be accessed anywhere within the methods 
     public void Go()
      {         
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
