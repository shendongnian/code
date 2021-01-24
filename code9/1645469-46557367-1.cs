    var result = 
        persons.GroupBy(p => new { p.FirstName, p.LastName })
               .SelectMany(g => 
                          {
                              var isSingle = g.Count() == 1;
                              return g.Where(p => isSingle || !string.IsNullOrEmpty(p.Comment))
                          });
