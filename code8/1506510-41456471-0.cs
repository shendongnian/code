    int listCount = _itemCollection.Count;
                        for (int i = listCount - 1; i >= 0; i--)
                        {
                         var item = _itemCollection[i]; // just to prevent changes in all places inside the for loop
                         if(item['expirydate'] > today){
                             item.delete();
                          }    
                        }
