    public class Program
    {
    	public static void Main()
    	{
    		new GameManager(); //Prints GameManager
    		new ShooterGameManager(); //prints ShooterGameManager
    	}
    	
    	
    }
    
    public class Singleton<T>
    {
    	private T _instance;
    	
    	public Singleton()
    	{
    		Console.WriteLine(typeof(T).Name);
    	}
    }
    
    public class GameManager<T> : Singleton<T>
    {
    }
    
    public class GameManager : GameManager<GameManager>
    {
    }
    
    public class ShooterGameManager : GameManager<ShooterGameManager>
    {
    }
