    private string _MarkerID;
    [JsonIgnore]
    public string MarkerID
    {
        get
        {
            return _MarkerID;
        }
        set
        {
            _MarkerID = value;
            RaisePropertyChanged("MarkerID");
        }
    }
