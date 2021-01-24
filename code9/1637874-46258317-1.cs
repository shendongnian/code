    private async void button_Click(object sender, RoutedEventArgs e)
    {
        await Task.Delay(5000); // heavy operation executed in background
        label.Content = "Done"; // control back to the UI Thread that executes this
    }
