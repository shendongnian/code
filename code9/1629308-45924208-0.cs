    var data = new[] { 1, 2, 3, 4, 1, 0, 1, 0 };
    var result = 
        data.GroupBy(i => i)
            .OrderByDescending(group => group.Key)
            .Aggregate(new { Keys = new List<int>(), Duplicates = new List<int>() }, 
                       (lists, group) =>
                       {
                           lists.Keys.Add(group.Key);
                           var duplicates = Enumerable.Repeat(group.Key, group.Count() - 1);
                           lists.Duplicates.AddRange(duplicates);
                           return lists;
                       },
                       lists => lists.Keys.Concat(lists.Duplicates));
    // result is new[] { 4, 3, 2, 1, 0, 1, 1, 0 };
