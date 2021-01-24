    var items = new List<string>
        {
            "B,0",
            "A,1",
            "B,2",
            "A,3",
            "A,4",
            "B,5",
            "A,6",
            "A,7",
            "B,8"
        };
    var result = items.Select(x =>
                 {
                     var strValue = x.Split(',');
                     return Tuple.Create(strValue[0], Convert.ToInt32(strValue[1]));
                 })
                 .Take(size)
                 .GroupBy(x => x.Item1, x => x.Item2)
                 .Select(x => new Results
                 {
                    Key = x.Key,
                    Values = x.ToList()
                 })
                 .ToList();
