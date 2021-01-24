    //make the method async.
    private async void button_click(object sender, RoutedEventArgs e)
    {
    
    //...
    //assuming userMessage is textblock2.
    userMessage.Text = await MakeAPICallAsync();
    
    //...
    }
    //where MakeAPICallAsync() is another function defined as
    private async Task<string> MakeAPICallAsync()
    {
    //API call;
    return result;
    }
