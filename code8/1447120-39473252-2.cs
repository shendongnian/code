    var numberOfYears = 3;
    var list = users.Select(x =>
    {
        dynamic item = new ExpandoObject();
        item.Id = x.Id;
        item.Name = x.Name;
        item.Status = x.Status;
        var p = item as IDictionary<string, object>;
        var recordsType = x.Records.GetType();
        for (var i = 1; i <= numberOfYears; ++i)
            p["Y" + i] = recordsType.GetProperty("Y" + i).GetValue(x.Records);
        return item;
    }).ToList();
