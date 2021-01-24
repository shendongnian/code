    async void DispatcherTimer_Tick(object sender, EventArgs e)
    {            
        // Updating the Label which displays the current second
        lblTime.Content = DateTime.Now.ToString("HH:mm:ss");
        lblSizeBTC_USD.Content = "SIZE " + await Task.Run(() => Api.GetProductTicker(productId).Result.size);        
        // Forcing the CommandManager to raise the RequerySuggested event
        CommandManager.InvalidateRequerySuggested();
    }
