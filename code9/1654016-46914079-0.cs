    return doc.Descendants(ns + "Order").Select(address => new FormsPersistence()
                   {
                       AmazonOrderId = (string)address.Element(ns + "AmazonOrderId").Value ?? string.Empty,
                       PurchaseDate = (string)address.Element(ns + "PurchaseDate").Value ?? string.Empty,
                       BuyerName = (string)address.Element(ns + "BuyerName").Value ?? string.Empty,
                       BuyerEmail = (string)address.Element(ns + "BuyerEmail").Value ?? string.Empty,
                       OrderStatus = (string)address.Element(ns + "OrderStatus").Value ?? string.Empty,
                       ShippingAddress = address.Elements(ns + "ShippingAddress").Select(shipping => new {
                            name = (string)shipping.Element(ns + "Name")
                       }).FirstOrDefault() 
                   }).ToList();
