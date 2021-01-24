    public RLFDatabaseTableViewModel()
    {
        LoadDBInstances();
        LoadDBInfoCommand = new RelayCommand(LoadDBInfo);
        SelectedDBInstance = DBInstances[0]; //selected the first item
    }
