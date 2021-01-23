    var customers = from c in _dbContext.Customer
        join a in _dbContext.Address on c.Id equals a.EntityId into g
        select new
        {
            c.Id,
            c.CompanyName,
            c.FirstName,
            c.LastName,
            Address = g.ToList()
        };
