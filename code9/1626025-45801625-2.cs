    public HomeViewModel()
    {
        this.RefreshUsers();
        userListClick = new RelayCommand<SelectionChangedEventArgs>(_userListClick);
        saveUser = new RelayCommand(saveUser, CanExecuteSaveUser);
        selectedUserViewModel.PropertyChanged += SelectedUserOnPropertyChanged;
    }
    private void SelectedUserOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        if (propertyChangedEventArgs.PropertyName.Equals(nameof(UserViewModel.username)))
        {
            (saveUser as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }
