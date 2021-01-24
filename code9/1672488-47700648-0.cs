    private async void BtnConect_OnClicked(object sender, EventArgs e)
    {
        activityIndicatorLogin.IsRunning = true;
        await Task.Delay(1000);
        await TEST();
    }
    
    protected async Task TEST()
    {
        activityIndicatorLogin.IsRunning = false;
        await DisplayAlert("tiitle test", "messsage test", "close");
    }
