    private static void MasterListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var newCol = e.NewValue as ObservableCollection<MyObject>;
        if (newCol != null)
        {
            newCol.CollectionChanged += Coll_CollectionChanged;
        }
        var oldCol = e.OldValue as ObservableCollection<MyObject>;
        if (oldCol != null)
        {
            oldCol.CollectionChanged -= Coll_CollectionChanged;
        }
    }
    private static void Coll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        //do something...
    }
