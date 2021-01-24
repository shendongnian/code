    // Just check if value is different from the actual backing field.
    // If and only if it is, set the backing field and raise the PropertyChanged event.
    public string SearchText
    {
        get { return _SearchText; }
        set
        {
            if (!EqualityComparer<string>.Default.Equals(_SearchText, value))
            {
                _SearchText = value;
                NotifyPropertyChanged();
            }
        }
    }
    private string _SearchText;
