    var contextQueryable = context.GetQueryable<CustomSearchResultItem>().Where(query).GetResults();
    var result = contextQueryable.Select((x, i) => new { Item = x, Index = i })
       .FirstOrDefault(itemWithIndex => itemWithIndex.Item.Document.ItemId.Guid == ItemId);
    
    if (result != null)
      index = result.Index;
