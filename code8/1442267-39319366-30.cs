    public string SelectedUserName
    {
        get { return SelectedUser.Name; }
        set
        {
            SelectedUser.Name = value;
            OnPropertyChanged(nameof(SelectedUserName));
        }
    }
