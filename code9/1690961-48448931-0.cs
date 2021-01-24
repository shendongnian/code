    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Task t = SomeAsync();
        MessageBox.Show("before end");
        await t; 
        MessageBox.Show("after end");
    }
