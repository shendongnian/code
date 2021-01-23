        int listCount = _itemCollection.Count; 
        for (int i = 0; i < listCount; i++)
        {
            var item = _itemCollection[i];
            if(item [expirydate] > today)
            {
                _itemCollection.Remove(item);
                listCount--;
            }
        }
    
