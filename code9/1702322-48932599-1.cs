    public Users Users
    {
        get { return _user; }
        set
        {
            _user = value;
            OnPropertyChanged("Users");
            navigationCandidates.RaiseCanExecuteChanged();
        }
    }
