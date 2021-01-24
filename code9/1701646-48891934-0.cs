    ObservableCollection<Role> selectedRoles;
    public ObservableCollection<Role> SelectedRoles
    {
        get { return selectedRoles; }
        set
        {
            selectedRoles = value;
            OnPropertyChanged("SelectedRoles");
        }
    }
