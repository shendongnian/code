    var products = document.QuerySelectorAll("div.product");
    foreach (var product in products)
    {
    	var productTitle = product.ChildNodes
    							  .First(o => o.NodeType == AngleSharp.Dom.NodeType.Text 
    											&& o.TextContent.Trim() != "");
    	Console.WriteLine(productTitle.TextContent.Trim());
    }
