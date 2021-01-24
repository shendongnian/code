    var existedIds = new HashSet<string>(list1.Select(class1 => class1.ItemId));
    var missingItems = 
        list2.Where(class2 => existedIds.Contains(class2.ItemId) == false)
             .Select(class2 => new Class1 
             { 
                 ItemId = class2.ItemId, 
                 Sales = 0 
             }); 
    list1.AddRange(missingItems);
