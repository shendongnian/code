    ObservableCollection<ProductTemporary> result = new ObservableCollection<ProductTemporary>();//ProductsTempController.Instance.SelectAll();
    result.CollectionChanged += (ss, ee) => 
    {
        if(ee.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove 
            && ee.OldItems !=null && ee.OldItems.Count > 0)
        {
            ProductTemporary removedItem = ee.OldItems[0] as ProductTemporary;
            ProductTemporaryController.Instance.Delete(removedItem.Id);
            UpdateTotalAmount();
        }
    };
