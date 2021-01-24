    private RelayCommand<YourClass> addUserCommand;
    public ICommand AddUserCommand
    {
        get
        {
            return addUserCommand ??
                (addUserCommand = new RelayCommand<YourClass>(param => this.AddUser(param)));
        }
    }
    public vol AddUser(YourClass obj)
    {
        string IDUser = obj.IDUser;
        bool isChecked = obj.IsChecked;
        // Do some stuff
    }
