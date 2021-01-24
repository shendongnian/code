    public GPHDTModel()
    {
        _fields.Add("MessageID", null); // initialize with default value
    }
    public string MessageID
    {
        get { return _fields["MessageID"]; }
        set {
           if (_fields["MessageID"] == value)
              return;
           _fields["MessageID"] = value;
           OnPropertyChanged("MessageID");
        }
    }
