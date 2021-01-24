    private string _startText;
    public string StartText
    {
        get => this._startText;
        set
        {
            this._startText;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartText)));
        }
    }
