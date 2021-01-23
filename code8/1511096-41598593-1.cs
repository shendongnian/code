    private async Task RetrieveAllData()
    {
        IsBusy = true;
        MyFooCollection = await SomeLookups.GetFoosAsync();
        IsBusy = false;
    }
