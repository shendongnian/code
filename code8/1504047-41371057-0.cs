    var categories = result.OrderBy(n => n.FacilityName).Select(n => n.FacilityName).Distinct().ToArray();
    var paddedData = new List<Tuple<string, int>>();
    result.OrderBy(n => n.FacilityName).GroupBy(n => n.TypeOfService).ToList().ForEach(n =>
    {
        foreach (var category in categories)
        {
            var newItem = new Tuple<string,int>
            (
                n.Key,
                result.FirstOrDefault(item => item.FacilityName == category && item.TypeOfService == n.Key)?.ServiceCount ?? 0
            );
            paddedData.Add(newItem);
        }
    });
    var data = paddedData.GroupBy(n => n.Item1).Select(n => new
    {
        name = n.Key,
        data = n.Select(x => x.Item2).ToArray()
    });
    var shapedData = new
    {
        series = data,
        categories
    };
