    var entities = Persons.Include(h => h.Cars)
                          .Where(h => h.Id == 1)
                          .OrderBy(h => h.Name)
                          .Select(p => new Person(){
                              Id = p.Id,
                              Name = p.Name,
                              Cars = p.Cars.OrderBy(c => c.Name).ToList()
                          });
