    public void Test()
    {
        Button button = new Button();
        Visibility visibility = Visibility.Collapsed;
    
        button.SetVisibility(visibility);
        //or
        ButtonExtensions.SetVisibility(button, visibility);
    }
