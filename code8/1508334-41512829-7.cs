    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var content = (string)button.Content;
        Task.Run(() => MessageBox.Show(content));
    }
