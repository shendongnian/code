    var result = list.GroupBy(rec => rec.ID)
                     .ToDictionary(
                         group => group.Key,
                         group => group.GroupBy(stat => stat.Name)
                                       .ToDictionary(g => g.Key, g => g.Select(stat => new {stat.Title, stat.Basic, stat.Message}).ToList())
                                  );
                           
