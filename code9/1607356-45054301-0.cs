    #region RegisterCommand
    
    private DelegateCommand _registerCommand;
    public ICommand RegisterCommand
    {
        get
        {
            _registerCommand = new DelegateCommand(param => Register(), () => CanRegister());
            return _registerCommand;
        }
    }
    
    private bool CanRegister()
    {
        return _isUserNameUnique && _isStrongPassword;
    }
    public string UserName
    {
     get {return _userName;}
     set
     {
      _userName = value;
      OnUserNameChanged();
     }
    }
    
    public string Password
    {
     get {return _password;}
     set {_password = value; OnPasswordChanged();
    }
    
    private void OnUserNameChanged()
    {
      _isUserNameUnique = VerifyUserNameIsUnique(_userName);
      _registerCommand.RaiseCanExecuteChanged();
    }
    
    private void OnPasswordChanged()
    {
      _isStrongPassword = VerifyIsStrongPassword();
      _registerCommand.RaiseCanExecuteChanged();
    }
    
    private void Register()
    {
        var newUser = new User
        {
            FirstName = _firstname,
            LastName = _lastname,
            Username = _username,
            Password = "", // TODO: Hashing and storing of passwords
        };
        using (var context = new WorkstreamContext())
        {
            var users = context.Set<User>();
            users.Add(newUser);
            context.SaveChanges();
        }
    }
    
    #endregion
