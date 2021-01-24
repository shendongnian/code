    private async void RecvData(object sender, RoutedEventArgs e)
    {
        while(server.hasClient)
        {
            string text = await server.AllReadLineAsync();
            txtOutputLog.AppendText(text);
        }
    }
