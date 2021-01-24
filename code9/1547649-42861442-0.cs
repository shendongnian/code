    public class GameServiceManager
    {
      public static GameServiceManager Instance { get; protected set; }
    
      public GameServiceManager()
      {
        if (GameServiceManager.Instance != null)
          throw new Exception("singleton has already been created");
    
        GameServiceManager.Instance = this;
      }
    }
