    var itemPrices = Collection.Select(item =>
    {
        var x = 10;
        var y = item.Price;
        return new { ItemName = item.Name, ItemPrice = x * y };
    });
    itemPrices.ForEach(itemData =>
    {
        console.WriteLine(itemData.ItemName + " " + itemData.ItemPrice.ToString());
    });
    
