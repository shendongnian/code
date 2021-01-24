                var result = from p in entites.Products
                             join o in entites.Order_Details on p.ProductID equals o.ProductID
                             select new ProductVm
                             {
                                 ProductName = p.ProductName,
                                 QuantityPerUnit = p.QuantityPerUnit,
                                 UnitPrice = p.UnitPrice.Value,
                                 UnitsInStock = p.UnitsInStock.Value,
                                 UnitsOnOrder = p.UnitsOnOrder.Value,
                                 ReorderLevel = p.ReorderLevel.Value,
                                 OrderDetails = p.Order_Details.Select(x =>
                                 new OrderDetailVm
                                 {
                                     ProductId = o.ProductID
                                 })
                             };
                return result.ToList();
