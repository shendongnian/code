    protected override void OnStart ()
    {
    	getCountry();
    }
    
    private async void getCountry()
    {
        var url = "...";
        GettingCountry gettingCountry = new GettingCountry();
        await gettingCountry.FetchAsync(url);
    }
