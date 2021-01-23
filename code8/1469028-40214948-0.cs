    DataTable dt = new DataTable(); 
    dt.Clear();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    DataRow dr = dt.NewRow();
    dr ["Column1"] = "100";
    dr ["Column2"] = "500";
    dt.Rows.Add(dr);
