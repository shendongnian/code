    public UsersViewModel()
    {
        SelectedUsers = new ArrayList();
        Users = new ObservableCollection<UserModel>();
        Users.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
        UsersViewSource = new CollectionViewSource() { Source = Users };
        InitializeListCommand = new RelayCommand(p => Users.Count == 0, p => InitializeList());
        InitializeListCommand.Execute(null);
        DeleteFirstUserCommand = new RelayCommand(p => Users.Count > 0, p => DeleteFirstUser());
        DeleteLastUserCommand = new RelayCommand(p => Users.Count > 0, p => DeleteLastUser());
    }
    
    private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Remove)
            foreach (UserModel item in e.OldItems) SelectedUsers.Remove(item);
    }
