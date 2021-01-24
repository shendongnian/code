    db.tblCustomerBuys.
            .GroupBy(buy => new 
            {
                Year = Convert.ToInt32(buy.BuyDate.Substring(0, 4)),
                ProductID = Convert.ToInt32(buy.ProductID),
                Major = (Convert.ToBoolean(db.tblCustomers.First(x => x.CustomerID == buy.CustomerID).IsMajor) == true ? "Major" : "Normal"),
                Month = ClassDate.MonthName(Convert.ToInt32(buy.BuyDate.Split('/')[1])),
                Season = ClassDate.SeasonName(Convert.ToInt32(buy.BuyDate.Split('/')[1]))
            })
            .Select(x => new
            {
                Year = x.Key.Year,
                ProductID = x.Key.ProductId,
                Price = x.Sum(i => Convert.ToInt32(i.Price)),
                Amount = x.Sum(i => Convert.ToDouble(i.Amount)),
                Major = x.Key.Major,
                Month = x.Key.Month,
                Season = x.Key.Season
            }).ToList();
