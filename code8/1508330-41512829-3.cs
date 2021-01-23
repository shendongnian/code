    private async void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var content = (string)button.Content;
        await Task.Run(() => MessageBox.Show(content));
    }
