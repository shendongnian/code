    private void CheckForNewItems()
    {
        var items = GetChangedItems();
        if (items == null)
        {
            return;
        }
        foreach (var item in items )
        {
            var itemDB= GetItem(item.id);
            if (itemDB!=null)
            {
                itemDB.somevalue= item.somevalue;
                SaveToDatabase(itemDB);
            }
        }
    }
    
