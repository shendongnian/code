    public ICommand LoadCommand
    {
        get
        {
            if (_loadCommand == null)
                _loadCommand = new RelayCommand(async o => await OnLoadAsync(), CanLoad);
            return _loadCommand;
        }
    }
    private async Task OnLoadAsync()
    {
        await Task.Run(() => MyLongRunningProcess());
    }
