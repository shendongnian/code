    string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set
        {
            if (_firstName != value)
                SendCommand.ChangeCanExecute();
            SetProperty(ref _firstName, value, nameof(FirstName));
        }
    }
    string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set
        {
            if (_lastName != value)
                SendCommand.ChangeCanExecute();
            SetProperty(ref _lastName, value, nameof(LastName));
        }
    }
    string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
                SendCommand.ChangeCanExecute();
            SetProperty(ref _email, value, nameof(Email));
        }
    }
    Command _sendCommand;
    public Command SendCommand 
    {
        get
        {
            return _sendCommand ?? (_sendCommand = new Command(OnSend, CanSend));
        }    
    }
    bool CanSend(object obj)
    {
        return Validate();
    }
    void OnSend(object obj)
    {
        if(Validate())
        {
            //actual button click execution
        }
    }
    bool Validate()
    {
        // disable button if any entry empty
        return !string.IsNullOrEmpty(_firstName)
                      && !string.IsNullOrEmpty(_lastName)
                      && !string.IsNullOrEmpty(_email);
	}
