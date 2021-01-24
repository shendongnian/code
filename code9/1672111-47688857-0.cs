    var query = context.DataTable.Where(x => x.Id == 0);
    foreach (var item in queryList)
        query = query.Union(context.DataTable.Where(i => i.ValueName == item.ValueName && i.Symbol == symbol && i.Days == item.Days));
    
    var allData = query.ToList();
    if (allData.Count() > 0)
        context.DataTable.RemoveRange(allData);
