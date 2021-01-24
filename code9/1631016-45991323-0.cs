    var itemsGrouped = this.Errors.GroupBy(x => x.UniqueName).AsEnumerable();
    var invalidItems = itemsGrouped.Where((f) =>
    {
        var errorCount = f.ToArray()
        .Where(x => x.ErrorCount.HasValue)
        .Count(x => x.ErrorCount.Value > 0);
    
        return errorCount > 2;
    });
    
    var hasErrors = !invalidItems.Any();
    //Do stuff with invalidItems
