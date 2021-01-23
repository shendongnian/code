    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        PB.IsIndeterminate = true;
    
        await DoWorkAsync();
    
        PB.IsIndeterminate = false;
    }
