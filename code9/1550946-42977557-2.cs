    private static ObservableCollection<ObjA> _collectionA;
    public static ObservableCollection<ObjA> CollectionA {
        get { return _collectionA; }
        set {
            if (_collectionA != value)
            {
                _collectionA = value;
                if (_collectionA != null)
                {
                    _collectionA.CollectionChanged += myHandler;
                }
            }
        }
    }
    static myViewModel()
    {
        //  Now, whenever you replace CollectionA, the setter will add the changed 
        //  handler automatically and you don't have to think about it. 
        CollectionA = new ObservableCollection(CollectionB.Select(abc=> new(abc, True));
    }
