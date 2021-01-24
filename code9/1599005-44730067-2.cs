    DataSet ds = new DataSet();
    DataTable dt1 = new DataTable();
    dt1.Columns.Add("id", typeof(int));
    dt1.Columns.Add("name", typeof(string));
    
    ds.Tables.Add(dt1);
    
    for (int i = 0; i < 10; i++)
    {
        DataRow dr = dt1.NewRow();
        dr["id"] = i;
        dr["name"] = "Item " + i.ToString();
        dt1.Rows.Add(dr);
    }
    
    string s = JsonConvert.SerializeObject(ds.Tables[0]);
    Debug.WriteLine(s);
