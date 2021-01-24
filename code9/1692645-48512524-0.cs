    var data = dataTable.Rows.Cast<DataRow>()
        .Select(r => dataTable.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => r[c.ColumnName]))
        .ToList();
    var mapping = mappingTable.Rows.Cast<DataRow>()
        .Where(r => !r["parentID"].Equals(DBNull.Value))
        .ToLookup(r => (int)r["parentID"], r => (int)r["id"]);
    var output = new List<Dictionary<string, Object>>();
    foreach (var group in mapping) {
        data[group.Key - 1].Add("children", group.Select(c => data[c - 1]).ToList());
        output.Add(data[group.Key - 1]);
    }
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(output);
