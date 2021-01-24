    var res = list1.Concat(list2)
        .GroupBy(p => p.Key)
        .ToDictionary(
            g => g.Key
        ,   g => g.SelectMany(p => p.Value).Distinct().ToList()
        );  //                              ^^^^^^^^^^
            // Remove Distinct() if you would like to keep all items
