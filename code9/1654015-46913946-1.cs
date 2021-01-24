      return from address in doc.Descendants(ns + "Order")
             let shipping=address.Element(ns+"ShippingAddress")
             select new FormsPersistence
               {
                   AmazonOrderId = (string)address.Element(ns + "AmazonOrderId").Value ?? string.Empty,
                   PurchaseDate = (string)address.Element(ns + "PurchaseDate").Value ?? string.Empty,
                   BuyerName = (string)address.Element(ns + "BuyerName").Value ?? string.Empty,
                   BuyerEmail = (string)address.Element(ns + "BuyerEmail").Value ?? string.Empty,
                   OrderStatus = (string)address.Element(ns + "OrderStatus").Value ?? string.Empty,
                   ShippingAddress= new ShippingAddress{Name=(string)shipping.Element(ns+"Name"),
                                                        AddressLine=(string)shipping.Element(ns+"AddressLine1"),
                                                       }
               };
