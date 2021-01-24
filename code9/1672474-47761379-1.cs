    internal static void TestGameParser()
    {            
        DoGame<SomeScoreboard>();
    }
    private static void DoGame<T>() where T:IScoreBoard
    {
        var game = new Game<T>();
        DtoParserFactory factory = new DtoParserFactory();
        var parser = factory.Get<T>();
        parser.Parse(game.Scoreboard);            
    }
