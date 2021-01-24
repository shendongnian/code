    var result =
        table.AsEnumerable()
        .GroupBy(x => new { Code = x["Code"], SourceType = x["Source Type"] })
        .Select(x => summary.Rows.Add(x.Key.Code, x.Key.SourceType, x.Count()))
        .CopyToDataTable();
