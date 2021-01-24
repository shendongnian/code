    public async void GetShows(string serviceDocUri)
    {
        _Shows = new ObservableCollection<Show>();
        await Task.Run(
            () =>
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new Action(() => GetAllShowsWithPath("", directoryShowDoc))));
    }
