        var xDoc = XDocument.Parse(xmlResult);
        XNamespace ns = "urn:ebay:apis:eBLBaseComponents";
        var orderElements = xDoc.Elements(ns + "GetOrdersResponse")
                .Elements(ns + "OrderArray").Elements(ns + "Order");
        foreach (XElement elem in orderElements)
        {
            var orderId = (int)elem.Element(ns + "OrderID");
        }
    
