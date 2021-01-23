    var list = new[] { new { Name = "", Code = "", Plan = "" } }.ToList();
    
    for (var i = 0; i < mem.Length; i++)
    {
        // change the logic to extract all values from line
        var values = mem[i].Split(',');
    
        list.Add(new { Name = values[0].Trim(), Code = values[1].Trim(), Plan = values[2].Trim() });
    }
    
    var plans = list.Where(item => !String.IsNullOrEmpty(item.Plan)).Select(item => item.Plan).Distinct().ToList();
    
    var dataSet = new DataSet();
    
    foreach (var plan in plans)
    {
        var dataTable = new DataTable(plan);
    
        dataTable.Columns.Add(new DataColumn("Name", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Code", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Plan", typeof(String)));
    
        var childs = list.Where(item => item.Plan == plan).ToList();
    
        foreach (var child in childs)
        {
            var newRow = dataTable.NewRow();
    
            newRow["Name"] = child.Name;
            newRow["Code"] = child.Code;
            newRow["Plan"] = child.Plan;
    
            dataTable.Rows.Add(newRow);
        }
    
        dataSet.Tables.Add(dataTable);
    }
