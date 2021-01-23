    var services = _serviceDbSet
                  .Include(b => b.Users)
                  .Include(b => b.Users.Select(x => x.Address))
                  .ToList()
                  .Select(s => new    
                               {
                                    Id = s.Id,
                                    Users = s.Users
                               });
