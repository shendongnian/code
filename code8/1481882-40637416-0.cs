    db.tbl
        .GroupBy(a => a.ID)
        .Select(b => new {
            CompanyName = c.First().CustomerName,
            CustomerId = (int) c.Key,
            TotalQuotes = c.Count()
        });
