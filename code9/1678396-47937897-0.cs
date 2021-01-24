    var groupCounts = productionLala.Where(n => n.Date >= x.StartDate && n.Date < x.EndDate)
        .GroupBy(x => new
        {
            x.From_Location_ID,
            x.SDMaterial_Group
        })
        .Select(x => new
        {
            From_Location_ID = x.Key.From_Location_ID,
            SDMaterial_Group = x.Key.SDMaterial_Group,
            Count = x.Count()
        });
