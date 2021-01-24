    var data = dataTable.Rows.Cast<DataRow>()
                        .Select(r => dataTable.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => r[c.ColumnName]))
                        .ToList();
    
    var mapping = mappingTable.Rows.Cast<DataRow>()
                              .Where(r => !r["parentID"].Equals(0))
                              .ToLookup(r => (int)r["parentID"], r => (int)r["id"]);
    
    var output = new List<Dictionary<string, Object>>();
    foreach (var parent in mappingTable.Rows.Cast<DataRow>().Where(r => r["parentID"].Equals(0))) {
        var parentID = (int)parent["id"];
    
        if (mapping.Contains(parentID))
            data[parentID-1].Add("children", mapping[parentID].Select(c => data[c-1]).ToList());
        output.Add(data[parentID-1]);
    }
