    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button newButton = new Button { Content = "CreatedBtn" };
        newButton.Click += Button_Click;
        RelativePanel.SetLeftOf(newButton,sender);
        myPanel.Children.Add(newButton);
    }
