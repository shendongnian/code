    var oldItems = new List<Items>(); // suppose it has 5000 items...
    var newItems = new List<Items>(); // suppose it has 15000 items...
    
    var thirdList = newItems.GetNewOrModifiedItems(
        oldItems,
        x => x.ItemId,
        CustomComparer.Instance);
