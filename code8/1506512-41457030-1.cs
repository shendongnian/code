        int listCount = _itemCollection.Count;
        //_itemCollection is of type SPListItemCollection  
        for (int i = 0; i < listCount; i++)
        {
            var item = _itemCollection[i];
            if(item [expirydate] > today)
            {
                _itemCollection.Remove(item);
                listCount--;
            }
        }
    
