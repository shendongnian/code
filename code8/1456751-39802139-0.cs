    private void ChangePosition(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var newPosition = new Thickness(10, 90, 40, 80); // assuming this is your new position
        button.Margin = newPosition;
    }
