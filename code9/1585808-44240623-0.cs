    private void Feld_Click(object sender, RoutedEventArgs e)
    {
        var currentButton = (Button)object;
        
        if (Player1RButton.IsChecked == true)
        {
            currentButton.Background = Brushes.Green;
        }
    }
