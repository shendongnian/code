    public class MyGame : Game
    {
       public MyGame()
       {
          // Should move to Initialize..
          this.Activated += ActivateMyGame;
          this.Deactivated += DeactivateMyGame;
          this.IAmActive = false;
       }
       public bool IAmActive { get; set; }
    
       public void ActivateMyGame(object sendet, EventArgs args)
       {
          iAmActive = true;
       }
    
       public void DeactivateMyGame(object sendet, EventArgs args)
       {
          iAmActive = false;
       }
    }
    
