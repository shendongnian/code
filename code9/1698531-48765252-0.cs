        var result = await ctx.SalesLines.Where(x => x.Sale.ShopId == 82).Select(x => new
        {
            ShopName = x.Sale.Shope.Name,
            SaleDate = x.TransactionDate,
            SaleID = x.Sale.ID,
            SalesLineID = x.ID,
            SalesQuantity = x.Quantity,
            SalesTotalPrice = x.TotalPrice,
            SalesDiscount = x.TotalDiscount,
            SalesVAT = x.VAT
        }).GroupBy(x => new { x.ShopName, x.SaleDate }).OrderBy(x => x.SaleDate).ToListAsync();
        var salesReport = new List<DailySalesDataModel>();
        if(result != null)
        {
            foreach(var p in result)
            {
                salesReport.Add(new DailySalesDataModel
                {
                    CountOfSales = p.Distinct(x => x.SaleID).Count(),
                    CountOfSalesLines = p.ToList().Count(),
                    SalesDate = p.Key.SaleDate,
                    SumOfQuantity = p.Sum(x => x.SalesQuantity),
                    SumOfTotalDiscount = p.Sum(x => x.SalesDiscount),
                    SumOfTotalPrice = p.Sum(x => x.SalesTotalPrice),
                    SumOfVAT = p.Sum(x => x.SalesVAT)
                });
            }
        }
