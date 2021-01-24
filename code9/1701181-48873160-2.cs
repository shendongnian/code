    public MainWindowViewModel()
    {
        Songs = GetSongs();
    }
    public ObservableCollection<Song> Songs { get; }
