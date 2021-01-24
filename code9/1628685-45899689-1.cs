    private usersVM _selectedUser;
    public usersVM selectedUser
    {
        get { return _selectedUser; }
        set
        {
            if (_selectedUser != value)
            {
                if (_selectedUser != null)
                {
                    _selectedUser.PropertyChanged -= propChangedHandler; 
                }
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    _selectedUser.PropertyChanged += propChangedHandler; 
                }
                RaisePropertyChanged("selectedUser");
            }
        }
    }
