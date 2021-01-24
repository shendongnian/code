    [JsonIgnore]
    private string _MarkerID;
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
