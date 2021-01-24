    // the method; your button click method
    private void ButtonClick() { 
       // create a new control
       // my example would be a button
       Button newButton = new Button();
       // the button's content
       newButton.Content = "Im a new button";
       // the click event listener
       newButton.Click += (_, __) => { // params: object sender, Clickeventargs
          // here should be the instructions of the button to perform when clicked
          Debug.Writeline("The new button has been clicked");
          // do some amazing stuffs
       }
       // add the button to the parent control; a grid or stachpanel, etc.
       someParentControl.Children.Add(newButton);
    }
