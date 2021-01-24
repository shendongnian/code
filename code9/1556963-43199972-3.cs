    private static Dictionary<INotifyCollectionChanged, NotifyCollectionChangedEventHandler> CurrentHandlers = new Dictionary<INotifyCollectionChanged, NotifyCollectionChangedEventHandler>();
    private static void OnChangeSelectedItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var usercontrol = d as MyCustomControl;
        var selected = e.NewValue as IList;
        var oldObservable = e.OldValue as INotifyCollectionChanged;
        var newObservable = e.NewValue as INotifyCollectionChanged;
        NotifyCollectionChangedEventHandler handler;
        if (oldObservable != null && CurrentHandlers.TryGetValue(oldObservable, out handler))
        {
            oldObservable.CollectionChanged -= handler;
            CurrentHandlers.Remove(oldObservable);
        }
        if (newObservable != null)
        {
            handler = new NotifyCollectionChangedEventHandler((sender, e2) => SelectedItemsContentChanged(sender, e2, usercontrol));
            newObservable.CollectionChanged += handler;
            CurrentHandlers.Add(newObservable, handler);
        }
        if (selected != null && selected.Count > 1)
        {
            //do something
        }
    }
    private static void SelectedItemsContentChanged(object sender, NotifyCollectionChangedEventArgs e, MyCustomControl usercontrol)
    {
        //do something
    }
