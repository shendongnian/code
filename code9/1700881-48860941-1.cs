    public bool IsUpdateAbleFile
    {
        get => this._isUpdateAbleFile;
        set
        {
            this._isUpdateAbleFile = value;
            OnPropertyChanged();
        }
    }
