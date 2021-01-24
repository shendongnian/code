    private string _messageID;
    public string MessageID
    {
      get { return _messageID; }
      set { 
          _messageID = value; 
          _fields["MessageID"] = value; // here
          OnPropertyChanged("MessageID");
      }
    }
