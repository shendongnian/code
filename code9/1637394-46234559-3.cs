     // Provinding that all LongRecordId are distinct
     var dict = source
        .ToDictionary(item => item.LongRecordId, item => item);
     ...
 
     foreach (var item in pList) {
       MyRecord foundItem = null; //TODO: Put the right type here
       // Instead of O(N) - FirstOrDefault we have O(1) TryGetValue
       if (dict.TryGetValue(item.LongRecordId, out foundItem)) {
         foundItem.Readonly = pReadonly;
         selectionList.Add(foundItem);
       } 
     }
