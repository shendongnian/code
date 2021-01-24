    var p1List = targetList.Select(item => item.Prop1).ToList();
    var p2List = targetList.Select(item => item.Prop2).ToList();
    var p3List = targetList.Select(item => item.Prop3).ToList();
    var preliminary = dbContext.BigTable
        .Where(item => p1List.Contains(item.Prop1)
                    && p2List.Contains(item.Prop2)
                    && p3List.Contains(item.Prop3))
        .AsEnumerable();
