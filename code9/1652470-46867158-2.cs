    private async void CheckConnection()
    {
        if(!CrossConnectivity.Current.IsConnected)
             await Navigation.PushAsync(new YourPageWhenThereIsNoConnection());
        else
             return;
    }
        
