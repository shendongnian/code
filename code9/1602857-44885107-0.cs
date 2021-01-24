    public event EventHandler<MyCollectionChangedEventArgs> CollectionChanged;
    protected virtual void OnCollectionChanged(object sender, MyCollectionChangedEventArgs e)
    {
        //2) TODO: History should be written, but I don't have the property name
        // sender is name
        // e.Action and e.Value are parameters
    }
