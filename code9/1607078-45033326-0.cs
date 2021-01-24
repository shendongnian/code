    string _tagList;
    public string TagList
    {
        get { return _tagList; }
        set
        {
            _tagList = value;
            OnPropertyChanged(); // [CallerMemberName]
            OnPropertyChanged(nameof(IsUntaggedEnabled));
        }
    }
    public bool IsUntaggedEnabled => TagList != "";
