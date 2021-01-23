    public void LoadLists( List<string> allServers, ObservableCollection<string> selectedServers )
    {
        foreach( string server in allServers )
            combo1.Items.Add( server );
        selectedServers.CollectionChanged += selectedServers_CollectionChanged;
        combo1.SelectedIndexChanged += ( object sender, EventArgs e ) => { selectedServers.Add( (string)combo1.SelectedItem ); };
    }
    private void selectedServers_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
        if( e.Action == NotifyCollectionChangedAction.Add )
            combo1.Items.Remove( e.OldItems[0] );
    }
