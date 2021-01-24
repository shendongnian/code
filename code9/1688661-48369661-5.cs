            int k = 0;
            var result =
                items.Select(x =>
                     {
                         var strValue = x.Split(',');
                         return Tuple.Create(strValue[0], Convert.ToInt32(strValue[1]));
                     })
                     .GroupBy(x => x.Item1, y => y.Item2)
                     .Select(x => Tuple.Create(x.Key, x))
                     .SelectMany(x => x.Item2.GroupBy(y => k++ / size, z => z).Select(z => Tuple.Create(x.Item1, z))
                     )
                     .Select(x => new Results()
                     {
                         Key = x.Item1,
                         Values = x.Item2.ToList()
                     })
                     .ToList();
