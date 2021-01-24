    public override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo( e );
        try
        {
           await Forecast.GetWeatherAsync();
           //after await finishes, Result is ready
           //do something with Forecast.Result
        }
        catch
        {
           //handle any exceptions
        }
    }
