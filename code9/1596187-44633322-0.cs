    public UsersViewModel()
    {
        SelectedUsers = new ArrayList();
        Users = new ObservableCollection<UserModel>();
        UsersViewSource = new CollectionViewSource() { Source = Users };
        InitializeListCommand = new RelayCommand(p => Users.Count == 0, p => InitializeList());
        InitializeListCommand.Execute(null);
        DeleteFirstUserCommand = new RelayCommand(p => Users.Count > 0, p => DeleteFirstUser());
        DeleteLastUserCommand = new RelayCommand(p => Users.Count > 0, p => DeleteLastUser());
    }
