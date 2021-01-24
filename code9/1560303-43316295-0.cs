    //Creates an instance of a sprite state (This includes the highlighted, pressed and disabled sprite.
    // Assign the sprites in edit mode
    public SpriteState sprState = new SpriteState();
    public Button BtnToChange;
    // You can even change the transition type
    public Selectable.Transition transition ;
     public void NavigationTask()
     {
         if (isBtnActive)
         {
             BtnToChange.interactable = false;
             BtnToChange.spriteState = sprState ;
         }
         else
         {
             BtnToChange.interactable = true;
         }
     }
