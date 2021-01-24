    private ObservableCollection<Prospect> _prospects = new ObservableCollection<Prospect>();
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
