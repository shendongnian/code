    DataTable dt = new DataTable();
    dt.Columns.Add("ProductId");
    dt.Columns.Add("ProductTotalPrice");
    DataRow dr = null;
    
    for (int i = 0; i < 10; i++)
    {
        dr = dt.NewRow(); // have new row on each iteration
        dr["ProductId"] = i.ToString();
        dr["ProductTotalPrice"] = (i*1000).ToString();
        dt.Rows.Add(dr);
    }
