    private List<Country> GetCountries()
            {
                var list = new Entity.Result<List<Entity.Country>>();
                list = _context.Countries.Select(tc => new Entity.Country
                {
                    Id = tc.Id,
                    Name = tc.Name,
                    IsdCode = tc.Code,
                }).ToList();
                return list.Data.Select(x => new Country
                {
                    id = x.Id,
                    Name = x.Name,
                }).ToList();
            }
 
