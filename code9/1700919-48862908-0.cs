    var columns = records.Columns.Cast<DataColumn>().ToArray();
    foreach (DataRow row in records.Rows)
    {
        var newFields = columns.Select(c => $@"""{row.Field<string>(c)}""");
        sUrl.WriteLine(string.Join("\t", newFields));
    }
