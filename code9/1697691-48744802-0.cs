    return DataContext.Set<SalesDTO>().FromSql($"EXECUTE spSalesList {centerID} {salesRep}")
                 .Select(x => new SalesDTO
                 {
                     Id = x.SalesID,
                     SalesID = x.SalesID,
                     CustomerID = x.CustomerID,
                     CustomerName = x.CustomerName,
                     SalesType = x.SalesType,
                     TotalAmount = x.TotalAmount,
                     SalesRep = x.SalesRep,
                     CenterName = x.CenterName,
                     OrderDate = x.OrderDate,
                     CenterID = x.CenterID
                 }).AsNoTracking().ToList();
