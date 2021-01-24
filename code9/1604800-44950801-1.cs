    private int _languageId;
    public int LanguageId
    {
        get
        {
            return _languageId;
        }
        set
        {
            if (_languageId != value)
            {
                _languageId = value;
                OnPropertyChanged("Languages");
                OnPropertyChanged();
            }
        }
    }
