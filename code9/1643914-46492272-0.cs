        var names = new List<Name>
        {
            new Name { FirstName = "AAA", LastName = "BBB"  },
            new Name { FirstName = "AAA", LastName = "BBB"  },
            new Name { FirstName = "CCC", LastName = "DDD"  }
        };
        var grouped = names.GroupBy(x => new { x.FirstName, x.LastName }).ToList();
        var result = grouped.SelectMany(x => 
        {
            var uniqueNames = new List<string>();
            if (x.Count() > 1)
            {
                var index = 1;
                foreach (var singleName in x)
                {
                    uniqueNames.Add($"{singleName.FirstName}{singleName.LastName}{index++}");
                }
            }
            else
            {
                uniqueNames.Add($"{x.Key.FirstName}{x.Key.LastName}");
            }
            return uniqueNames;
        }).ToList();
