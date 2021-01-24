        //Listening on Window_PreviewKeyDown any key pressing
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    { 
    
     if (e.Key == Key.Escape)
     {
        LockAllInputs();
     }
    
     if (e.Key == Key.Tab)
     {
        e.Handled = true;
     }
    
     if (e.Key == Key.F11)
     {
         this.Close();
     }
       // Opening modal when Key combination of CTRL AND F9 is pressed
       if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F9)
       {
         MyModal modal = new MyModal();
         modal.ShowDialog();
         e.Handled = true;//Here I've tried to prevent hitting another method which is being called when F9 is pressed
       }
    
       //Hitting a method when only F9 is pressed
        if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.F9)
        {
          CallAnotherMethod();
        }
    }
