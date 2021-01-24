     for(int i = 0; i < ListOfStoreObjects.Count; i++)
     {
         if( ListOfStoreObjects[i].ID == id && ListOfStoreObjects[i].CallType == callType)
         {
             ListOfStoreObjects.RemoveAt(i);
             break;
         }
     }
