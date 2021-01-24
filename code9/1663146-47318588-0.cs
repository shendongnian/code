    abstract public class GameManager : MonoBehaviour
    {
        protected GameManager() { whatever }
        // Lots of Methods and Properties...
    }
    public sealed class ShooterGameManager : GameManager
    {
      private ShooterGameManager() { whatever } 
      private static ShooterGameManager instance = new ShooterGameManager();
      public static ShooterGameManager Instance { get { return instance; } }
    }
