    _dbContext.Clients
                .Select(client => new
                {
                    client,
                    client.Countries
                }.Include(c=>c.Countries)`
