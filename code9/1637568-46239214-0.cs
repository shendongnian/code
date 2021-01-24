    private List<ModeMenuItem> _list;
    public List<ModeMenuItem> List 
    { 
        get => _list; 
        set
        {
            _list = value;
            RaisePropertyChanged();
        }
    }
