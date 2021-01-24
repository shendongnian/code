    public static async Task<ViewModel> InitializeAsync(string title)
    {
        await Task.Delay(2000); //do some init work...
        return new ViewModel(title);
    }
----------
    ViewModel vm = await ViewModel.InitializeAsync("...");
