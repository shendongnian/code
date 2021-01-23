    ObservableCollection<string> selectedServers = new ObservableCollection<string>();
    public void Load()
    {
        List<string> allServers = GetServerNames( "servers.xml" );
        foreach( ComputerPanel pnl in serverPanels )
            pnl.LoadLists( allServers, selectedServers );
    }
