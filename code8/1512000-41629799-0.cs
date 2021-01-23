    var table = new DataTable();
    table.Columns.Add("name", typeof(string));
    table.Columns.Add("code", typeof(int));
    table.Columns.Add("price", typeof(double));
    
    foreach(var obj in items) {
    	var row = table.NewRow();
    	row["name"] = obj.GetType().GetProperty("name").GetValue(obj, null);
    	row["code"] = obj.GetType().GetProperty("code").GetValue(obj, null);
    	row["price"] = obj.GetType().GetProperty("price").GetValue(obj, null);
    	table.Rows.Add(row);
    }
