    private static void OnChangeSelectedItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var selected = e.NewValue as IList;
        var oldObservable = e.OldValue as INotifyCollectionChanged;
        var newObservable = e.NewValue as INotifyCollectionChanged;
        if (oldObservable != null)
        {
            oldObservable.CollectionChanged -= SelectedItemsContentChanged;
        }
        if (newObservable != null)
        {
            newObservable.CollectionChanged += SelectedItemsContentChanged;
        }
        if (selected != null && selected.Count > 1)
        {
            //do something
        }
    }
    private static void SelectedItemsContentChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        //do something
    }
