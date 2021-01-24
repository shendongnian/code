    public string MessageID
    {
        get { return _messageID; }
        set 
        { 
            _messageID = value;
            Fields["MessageID"] = value
            OnPropertyChanged("MessageID");
        }
    }
