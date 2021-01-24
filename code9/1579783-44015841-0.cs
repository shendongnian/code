    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		new GameState(new Level1());
    		Console.WriteLine("Current level is " + GameState.CurrentLevel.Name);
    		Console.WriteLine("User leveled up");
    		GameState.CurrentLevel = new Level2();
    		Console.WriteLine("Current level is " + GameState.CurrentLevel.Name);
    	}
    }
    
    public class Level
    {	
    	public string Name;
    	// public static IEnumerable<Action> Actions { get; set; }
    }
    
    public class Level1 : Level
    {
    	public Level1()
    	{
    		// level 1 init
    		Name = "1";
    		// Actions = new List<Action> { ... }
    	}
    }
    
    public class Level2 : Level
    {
    	public Level2()
    	{
    		// level 2 init
    		Name = "2";
    	}
    }
    
    public class GameState
    {
    	public static Level CurrentLevel { get; set; }
    	
    	public GameState(Level startLevel)
    	{
    		CurrentLevel = startLevel;
    	}
    }
