    db.tbl
        .GroupBy(a => a.ID)
        .Select(c => new {
            CompanyName = c.First().CustomerName,
            CustomerId = (int) c.Key,
            TotalQuotes = c.Count()
        });
