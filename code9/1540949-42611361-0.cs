    DateTime beginningOfPreviousMonth = DateTime.Today
        .AddDays(-DateTime.Today.Day)
        .AddMonths(-1);
    productList.Where(p => p.date_sold.Date >= beginningOfPreviousMonth)
        .GroupBy(p => p.date_sold.Month)
        .Select(grp => new 
        {
            Month = new DateTime(1,key,1).ToString("MMMM"),
            ProductCount = grp.Distinct(x => x.product).Count(),
            CategoryCount = grp.Distinct(x => x.category).Count()
        });
