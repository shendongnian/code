    var dtSkus = new HashSet<string>();
    bool hasError = false;
    foreach (var row in _dataTable.AsEnumerable())
    {
    	var sku = row.Field<string>("skuColumn");
    	string type;
    	if (!dtSkus.Add(sku) || !allSkuTypes.TryGetValue(sku, out type) || type != "normalSKU")
    	{
    		hasError = true;
    		break;
    	}
    }
