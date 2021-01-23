     return _dbContext.Clients.Include(c=>c.Countries)
                .Select(client => new
                {
                    client,
                    client.Countries
                }).ToList().Select(data =>
                {
                    data.client.Countries = data.Countries; // Here is the problem
                    return data.client;
                }).ToList();
