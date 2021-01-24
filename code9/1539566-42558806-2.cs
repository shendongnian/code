    void CreateButton(string buttonName, 
                      string buttonIDText, 
                      string buttonText, 
                      PlaceHolder PlaceHolderName, 
                      EventHandler methodCall) // needed to fix your type
    {
        var button = new Button(); //reused variable name
        button.ID = buttonIDText;
        button.Text = buttonText;
        button.UseSubmitBehavior = false;
        button.Click += methodCall; // you dont need to do new EventHandler
        PlaceHolderName.Controls.Add(button);
    }
