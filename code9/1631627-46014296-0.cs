    public string MessageContent
    {
        get => _messageContent;
        set
        {
            _messageContent = value;
             OnPropertyChanged("MessageContent");
        }
    }
   
