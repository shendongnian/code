    var orderProducts = order
        .GroupBy(p => p.EX_CHAR_KEY1, (id, products) => new
        {
            Id = id,
            Description = products.Select(p => p.ORDD_DESCRIPTION).First(),
            Price = products.Select(p => Convert.ToDecimal(p.BVUNITPRICE)).First(),
            Quantity = products.Select(p => Convert.ToDecimal(p.BVORDQTY)).Sum(),
        });
    
    foreach (var item in orderProducts)
    {
        //...
        
        var total = item.Price * item.Quantity;
        
        xmlString.AppendFormat("<product no=\"{0}\">", inc);
        xmlString.AppendFormat("<FL val=\"Product Id\"><![CDATA[{0}]]></FL>", item.Id);
        xmlString.AppendFormat("<FL val=\"Product Description\"><![CDATA[{0}]]></FL>", item.Description);
        xmlString.AppendFormat("<FL val=\"List Price\"><![CDATA[{0}]]></FL>", item.Price);
        xmlString.AppendFormat("<FL val=\"Quantity\"><![CDATA[{0}]]></FL>", item.Quantity);
        xmlString.AppendFormat("<FL val=\"Net Total\"><![CDATA[{0}]]></FL>", total);
        xmlString.AppendFormat("<FL val=\"Total\"><![CDATA[{0}]]></FL>", total);
        
        // ...
    }
