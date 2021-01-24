    public async Task GetShows(string serviceDocUri)
    {
        _Shows = new ObservableCollection<Show>();
        await Task.Run(
            () =>
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new Action(() => GetAllShowsWithPath("", directoryShowDoc))));
    } 
   
    private async Task SetUpData()
    {
        await _VizManager.GetShows(_TrioLocalHost);
    
        //This is binded to my WPF combobox
        Workspace.This.TrioShow = _VManager._Shows;
    }
