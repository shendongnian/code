    private static ObservableCollection<ObjA> _collectionA;
    public static ObservableCollection<ObjA> CollectionA
    {
        get { return _collectionA; }
        set
        {
            if (_collectionA != value)
            {
                //  Remove handler from old collection, if any
                if (_collectionA != null)
                {
                    _collectionA.CollectionChanged -= myHandler;
                }
                //  1. Remove property changed handlers from old collection items (if old collection not null) 
                //  2. Add property changed to new collection items (if new collection not null) 
                AddAndRemovePropertyChangedHandlers(_collectionA, value, ObjA_PropertyChanged);
                _collectionA = value;
                if (_collectionA != null)
                {
                    _collectionA.CollectionChanged += myHandler;
                }
            }
        }
    }
    protected static void AddAndRemovePropertyChangedHandlers(
        System.Collections.IEnumerable oldItems, 
        System.Collections.IEnumerable newItems, 
        PropertyChangedEventHandler handler)
    {
        if (oldItems != null)
        {
            //  Some items may not implement INotifyPropertyChanged. 
            foreach (INotifyPropertyChanged oldItem in oldItems.Cast<Object>()
                .Where(item => item is INotifyPropertyChanged))
            {
                oldItem.PropertyChanged -= handler;
            }
        }
        if (newItems != null)
        {
            foreach (INotifyPropertyChanged newItem in newItems.Cast<Object>()
                .Where(item => item is INotifyPropertyChanged))
            {
                newItem.PropertyChanged += handler;
            }
        }
    }
    private static void ObjA_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
    private static void myHandler(object sender, 
        System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        //  If e.Action is Reset, you don't get the items that were removed. Oh well. 
        AddAndRemovePropertyChangedHandlers(e.OldItems, e.NewItems, ObjA_PropertyChanged);
    }
