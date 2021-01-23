    //// convert listBox items to string
    var listBoxItems = listBox.Items.Cast<String>().ToList();
    
    /// find duplicate Items
    var duplicateKeys = listBoxItems.GroupBy(x => x)
                            .Where(group => group.Count() > 1)
                            .Select(c => new { value = c.Key, count = c.Count() });
    
    //// generate duplicate item +index number
    foreach (var duplicateItem in duplicateKeys)
    {
        listBoxItems.Remove(duplicateItem.value);
        for (int i = 0; i < duplicateItem.count; i++)
        {
           listBoxItems.Add(duplicateItem.value + "i");
        }
     }
