            int k = 0;
            var result =
                items.Select(x =>                          // parse initial string
                     {
                         var strValue = x.Split(',');
                         return Tuple.Create(strValue[0], Convert.ToInt32(strValue[1]));
                     })
                     .GroupBy(x => x.Item1, y => y.Item2)  // group by key
                     .Select(x => Tuple.Create(x.Key, x))  // flatten to IEnumerable
                     .SelectMany(x =>                      // select fixed size data chunks
                         x.Item2.GroupBy(y => k++ / size, z => z)
                                .Select(z => Tuple.Create(x.Item1, z)))
                     .Select(x =>                          // cast to resulting model type
                         new Results()          
                         {
                             Key = x.Item1,
                             Values = x.Item2.ToList()
                         })
                     .ToList();                            // Return enumeration as list
