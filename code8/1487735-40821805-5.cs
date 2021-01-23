    private async void buttonTestJSFCHI_Click(object sender, RoutedEventArgs e)
    {
        JSON_Worker w = new JSON_Worker();
        await w.StartTask("FileInfo", "yourUrl");
        // This line will be executed only after asynchronous methods completes succesfully 
        // or exception will be thrown
        foreach (string res in w.ReturnedData)
        {
            textBoxResults.Text += res;
        }
    }
