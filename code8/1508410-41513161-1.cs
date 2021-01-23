    public async void TheLister()
    {
        var listMaker = new ListMaker();
        var countryList = await listmaker.GetCountryListAsync();
        // Do something with countryList
    }
