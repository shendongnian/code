    void CreateButton(string buttonName, 
                      string buttonIDText, 
                      string buttonText, 
                      PlaceHolder PlaceHolderName, 
                      EventHandler methodCall) // needed to fix your type
    {
        Button buttonName = new Button();
        buttonName.ID = buttonIDText;
        buttonName.Text = buttonText;
        buttonName.UseSubmitBehavior = false;
        buttonName.Click += methodCall; // you dont need to do new EventHandler
        PlaceHolderName.Controls.Add(buttonName);
    }
