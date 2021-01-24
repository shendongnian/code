    private void CheckForNewItems()
        {
            var items = GetChangedItems();
            if (items != null)
            {
                foreach (var item in items )
                {
                    var itemDB= GetItem(item.id);
                    itemDB?.somevalue= item.somevalue;
                    SaveToDatabase(itemDB);                   
                }
            }
        }
