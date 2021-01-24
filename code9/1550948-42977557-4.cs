    private static ObservableCollection<ObjA> _collectionA;
    public static ObservableCollection<ObjA> CollectionA {
        get { return _collectionA; }
        set {
            if (_collectionA != value)
            {
                //  Remove handler from old collection, if any
                if (_collectionA != null)
                {
                    _collectionA.CollectionChanged -= myHandler;
                }
                _collectionA = value;
                if (_collectionA != null)
                {
                    _collectionA.CollectionChanged += myHandler;
                    //  Whatever myHandler does on new items, you probably want to do 
                    //  that here for each item in the new collection. 
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
