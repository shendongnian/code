    DataTable dt = new DataTable(); 
    dt.Columns.Add("Column1");
    foreach(int num in arr)
    {
       DataRow dr = dt.NewRow();
        dr["Column1"] = num;
        dt.Rows.Add(dr);
    }
 
