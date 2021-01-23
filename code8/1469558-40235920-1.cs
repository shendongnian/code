    public ICommand SaveCommand {get; private set;}
    private async Task SaveMethodAsync() 
    {
        await dbService.SaveDataAsync(modelItem).ConfigureAwait(false);
        ...
    }
    public ViewModel()
    {
        SaveCommand = new RelayCommand(async () =>
            await SaveMethodAsync().ConfigureAwait(false));
    }
