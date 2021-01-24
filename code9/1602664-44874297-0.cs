    var missingItems = 
        list2.Where(class2 => list1.Any(class1 => class1.ItemId == class2.ItemId) == false)
             .Select(class2 => new Class1 
             { 
                 ItemId = class2.ItemId, 
                 Sales = 0 
             });
    list1.AddRange(missingItems);
