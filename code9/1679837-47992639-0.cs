    if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F9)
    {
      MyModal modal = new MyModal();
      modal.ShowDialog();
      e.Handled = true;//Here I've tried to prevent hitting another method which is being called when F9 is pressed
     }
    
    //Hitting a method when only F9 is pressed
    if (e.Key == Key.F9)
    {
      //This is invoked everytime after CTRL+F9
      CallAnotherMethod();
    }
