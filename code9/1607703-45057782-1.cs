    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            if (_password == value)
                return;
            _password = value;
            OnPasswordChanged();
            OnPropertyChanged("Password");
            _registerCommand.RaiseCanExecuteChanged(); //<--
        }
    }
