    var result = list1.Concat(list2).Concat(list3)
                      .GroupBy(item => new { item.Empid, item.Empname }, item => item.Rating)
                      .Select(g => new { 
                          Id = g.Key.Empid, 
                          Name = g.Key.Empname, 
                          Rating = g.Sum() });
