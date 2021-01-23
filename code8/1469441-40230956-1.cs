    var customers = _dbContext.Customer
        .GroupJoin(
            _dbContext.Address,
            c => c.Id,
            a => a.EntityId,
            (c, a) => new
            {
                c.Id,
                c.CompanyName,
                c.FirstName,
                c.LastName,                        
                Address = a.ToList()
            }
        );
