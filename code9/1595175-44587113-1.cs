    public ConfigRoleModel(int RoleId) //You don't need that collection in the parameter list since it doesn't look like you are using it
    {
        test = RoleId;
        _fullData = new ObservableCollection<ViewRoleMapClass>(WCFclient.getViewRoleMapsByRole(RoleId));       
        saveRole = new RelayCommand<Window>(configRole);
        ViewList = _fullData;
    }
