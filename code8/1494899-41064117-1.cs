    //// convert listBox items to string
    var listBoxItems = listBox.Items.Cast<String>().ToList();
    
    /// find duplicate Items
    var duplicateKeys = listBoxItems.GroupBy(x => x)
                            .Where(group => group.Count() > 1)
                            .Select(c => new { value = c.Key, count = c.Count() });
    
    //// generate duplicate item +index number
    foreach (var duplicateItem in duplicateKeys)
    {   
        for (int i = 1; i < duplicateItem.count+1; i++)
        {
          if (listBoxItems.Contains(duplicateItem.value))
          {
             listBoxItems.Remove(duplicateItem.value);
          }
          listBoxItems.Add(duplicateItem.value + i);
        }
     }
