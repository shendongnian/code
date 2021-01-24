    public class MyGame : Game
    {
       public MyGame()
       {
          // Should move to Initialize..
          this.Activated += ActivateMyGame;
          this.Deactivated += DeactivateMyGame;
       }
       public bool IAmActive { get; set; } = false;
    
       public ActivateMyGame()
       {
          iAmActive = true;
       }
    
       public DeactivateMyGame()
       {
          iAmActive = false;
       }
    }
    
