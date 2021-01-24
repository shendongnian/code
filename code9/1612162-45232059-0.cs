    List<string> addItems = new List<string>();
    foreach(var list in tblMainList)
    {
        con.Open();
        string query = "SELECT * FROM"+" "+list;
        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();
        dt = dr.GetSchemaTable();
        con.Close();
        foreach (DataRow dt_row in dt.Rows)
        {
             foreach (DataColumn dt_col in dt.Columns)
             {
                  lviewMainDbSchema.Items.Add(string.Format("{0}={1}", dt_col.ColumnName, dt_row[dt_col]).ToString());
                  //add new items to new list
                  addItems .Add(string.Format("{0}={1}", dt_col.ColumnName, dt_row[dt_col]).ToString());
             }
        }
    } 
            
    // add new List to tblMainList
    tblMainList.AddRange(addItems);
