    var groupedDataQuery = dataQuery
        .GroupBy(e => new AuditReportGroupingDataModelBase
        {
            GroupTime = (filters.TimeSpanId == (int)TimeSpanEnum.Daily ? e.InsertDay : filters.TimeSpanId == (int)TimeSpanEnum.Monthly ? e.InsertMonth : e.InsertDay).Value,
            CountryId = e.CountryId.Value
        })
        .Select(grp => new AuditReportGroupingDataModel
        {
            GroupTime = grp.Key.GroupTime,
            CountryId = grp.Key.CountryId,
            Count = grp.Count()
        });
