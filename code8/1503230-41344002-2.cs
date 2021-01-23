    _dbContext.Clients
                .Select(client => new
                {
                    client,
                    Countries = client.Countries.AsEnumerable() //perhaps tolist if it works
                }`
