    private ObservableCollection<Prospect> _prospects;
    public ObservableCollection<Prospect> Prospects
    {
        get
        {
            return _prospects;
        }
        set
        {
            _prospects = value;
            RaisePropertyChanged("Prospects");
        }
    }
