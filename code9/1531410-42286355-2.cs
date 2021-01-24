    observableCollection.CollectionChanged += (ss, ee) =>
    {
        if(ee.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            SomeType newItem = ee.NewItems[0] as SomeType;
            someObject.AddItem(newItem);
        }
    };
