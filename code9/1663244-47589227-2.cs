    public class MyGame : Game
    {
       public MyGame()
       {
          // Should move to Initialize-method..
          this.Activated += ActivateMyGame;
          this.Deactivated += DeactivateMyGame;
          this.IAmActive = false;
          // do you init-stuff
          // bring you window to front. After this point the "Game.IsActive"
          // will be set correctly, while IAmActive is correct from the beginning.
       }
       public bool IAmActive { get; set; }
    
       public void ActivateMyGame(object sendet, EventArgs args)
       {
          IAmActive = true;
       }
    
       public void DeactivateMyGame(object sendet, EventArgs args)
       {
          IAmActive = false;
       }
    }
    
