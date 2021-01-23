    var stackPanel = new StackPanel();
    var button = new Button();
    button.Content = "Your Button";
    button.Click += new System.Windows.RoutedEventHandler(Edit_Click);
    stackpanel.Children.Add(button);
