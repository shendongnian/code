    void CreateButton(string buttonName, 
                      string buttonIDText, 
                      string buttonText, 
                      PlaceHolder placeHolder, 
                      EventHandler methodCall) // needed to fix your type
    {
        var button = new Button(); //reused variable name
        button.ID = buttonIDText;
        button.Name = buttonName; //you missed assigning the button name
        button.Text = buttonText;
        button.UseSubmitBehavior = false;
        button.Click += methodCall; // you dont need to do new EventHandler
        placeHolder.Controls.Add(button);
    }
