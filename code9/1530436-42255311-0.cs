    var query = dataTable.AsEnumerable()
        .GroupBy(r => r.Field<int>("ID"))
        .Select(grp => new DataModel
        {
            Id = grp.Key,
            name = String.Join(",", grp.Select(t => t.Field<string>("name"))), //Because there could be multiple names
            RepeatedIDCollection = grp.Select(t => new RepeatedIDs
            {
                trId = t.Field<int>("trID"),
                trname = t.Field<string>("trName")
            }).ToList(),
        });
