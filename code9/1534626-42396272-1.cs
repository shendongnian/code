    var res = list
        .GroupBy(p => p.Key)
        .ToDictionary(
            g => g.Key
        ,   g => g.SelectMany(p => p.Value).Distinct().ToList()
        );  //                              ^^^^^^^^^^
            // Remove Distinct() if you would like to keep all items
