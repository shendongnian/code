    private async void DispatcherTimer_Tick(object sender, EventArgs e)
    {            
        // Updating the Label which displays the current second
        lblTime.Content = DateTime.Now.ToString("HH:mm:ss");
        var productTicker = await Api.GetProductTicker(productId);
        lblSizeBTC_USD.Content = "SIZE " + productTicker.size;        
        // Forcing the CommandManager to raise the RequerySuggested event
        CommandManager.InvalidateRequerySuggested();
    }
