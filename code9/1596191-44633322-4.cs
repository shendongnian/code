    public UsersViewModel()
    {
        ...
    
        Users.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
    }
    
    private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Remove)
            foreach (UserModel item in e.OldItems) SelectedUsers.Remove(item);
    }
