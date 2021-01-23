    var result = (from row in dt.AsEnumerable()
                  group row by row.Field<string>("Manufacture") into grouping
                  select new Car
                  {
                      Manufacture = grouping.Key,
                      ModelList = grouping.Select(item => new Model
                      {
                          Name = item.Field<string>("ModelName"),
                          Color = item.Field<string>("Color")
                      }).ToArray()
                  }).ToList();
