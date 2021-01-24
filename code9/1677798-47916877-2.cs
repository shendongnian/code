    var results = xDocument.Descendants(ns + "impot").Select(x => new {
    	ImpotNo = x.Attribute("impot-no")?.Value,
    	ProductLineItems = x.Descendants(ns + "product-lineitems").Select(y => new
    	{
    		Item = y.Descendants(ns + "product-lineitem").Select(z => new
    		{
    			Price = z.Element(ns + "price")?.Value,
    			SmallPrice = z.Element(ns + "Small-price")?.Value,
    			BigPrice = z.Element(ns + "Big-price")?.Value,
    		}).FirstOrDefault()
    	})
    });
    
    foreach (var result in results)
    {
    	foreach (var productLine in result.ProductLineItems)
    	{
    		dataToBeWritten.Append(result.ImpotNo);
    		dataToBeWritten.Append(";");
    		dataToBeWritten.Append(productLine.Item.Price);
    		dataToBeWritten.Append(";");
    		dataToBeWritten.Append(productLine.Item.SmallPrice);
    		dataToBeWritten.Append(";");
    		dataToBeWritten.Append(productLine.Item.BigPrice);
    		dataToBeWritten.Append(";");
    		dataToBeWritten.Append(0);
    		dataToBeWritten.Append(Environment.NewLine);
    	}
    }
