    private async void getCountry()
    {
        var url = "...";
        GettingCountry gettingCountry = new GettingCountry();
        var data = await gettingCountry.FetchAsync(url);
        await MainPage.Navigation.PushAsync(new FillingPage(data));
     }
