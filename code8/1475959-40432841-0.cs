    System.Data.DataTable dt = new System.Data.DataTable();
    
    dt.Columns.Add("first", typeof(string));
    dt.Columns.Add("last", typeof(string));
    dt.Columns.Add("full", typeof(string), "first + ' : ' + last");
    
    System.Data.DataRow row = dt.NewRow();
    row["first"] = "Donald";
    row["last"] = "Duck";
    dt.Rows.Add(row);
