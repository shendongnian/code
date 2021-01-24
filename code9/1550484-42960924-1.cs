    var entities = Persons.Include(h => h.Cars)
                          .Where(h => h.Id == 1)
                          .OrderBy(h => h.Name)
                          // .ToList() (Use this if calling directly from EF)
                          .Select(p => new Person(){
                              Id = p.Id,
                              Name = p.Name,
                              Cars = p.Cars.OrderBy(c => c.Name).ToList()
                          });
