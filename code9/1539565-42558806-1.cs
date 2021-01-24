    void CreateButton(string buttonName, 
                      string buttonIDText, 
                      string buttonText, 
                      PlaceHolder PlaceHolderName, 
                      EventHandler methodCall) // needed to fix your type
    {
        var button = new Button();
        button.ID = buttonIDText;
        button.Text = buttonText;
        button.UseSubmitBehavior = false;
        button.Click += methodCall; // you dont need to do new EventHandler
        PlaceHolderName.Controls.Add(button);
    }
