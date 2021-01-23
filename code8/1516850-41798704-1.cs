    protected override async void OnAppearing()
    {
        if (!ViewModelObjects.Languages.IsDataLoaded)
            await ViewModelObjects.Languages.LoadData();
    }
