    var result = dt.AsEnumerable()
                   .GroupBy(row => row.Field<string>("Manufacture"),
                            row => new Model
                            {
                                Name = row.Field<string>("ModelName"),
                                Color = row.Field<string>("Color")
                            })
                   .Select(group => new Car
                   {
                       Manufacture = group.Key,
                       ModelList = group.ToArray()
                   }).ToList();
