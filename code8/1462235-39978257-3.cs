    public void LoadLists( List<string> allServers, ObservableCollection<string> selectedServers )
    {
        foreach( string server in allServers )
            combo1.Items.Add( server );
        selectedServers.CollectionChanged += selectedServers_CollectionChanged;
        combo1.SelectedIndexChanged += ( object sender, EventArgs e ) => { selectedServers.Add( (string)combo1.SelectedItem ); };
    }
    private void selectedServers_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
        string newlySelectedServer = (string)e.NewItems[0];
        if( e.Action == NotifyCollectionChangedAction.Add 
            && (string)combo1.SelectedItem != newlySelectedServer ) //only if selector was not my own combo
            combo1.Items.Remove( newlySelectedServer );
    }
