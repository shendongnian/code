    DataTable dt = new DataTable();
    SqlDataReader reader = cmd.ExecuteReader();
    foreach (DataRow dr in reader.GetSchemaTable().Rows)
    {
        /*this was originally written to handle an arbitrary query, which means
          we might end up with multiple columns with the same name, which isn't allowed.
          use extrachars and n to make names like "ID1", "ID2", etc... */
        string colName = dr["ColumnName"].ToString();
        string extrachars = "";
        int n = 1;
        while (dt.Columns.Contains(colName + extrachars))
        {
            extrachars = n.ToString();
            n++;
        }
        dt.Columns.Add(colName + extrachars, Type.GetType(dr["DataType"].ToString()));
    }
    while (reader.Read())
    {
        DataRow dr = dt.NewRow();
        object[] tempArray = new object[dt.Columns.Count];
        reader.GetValues(tempArray);
        dr.ItemArray = tempArray;
        
        //either add it to a table
        dt.Rows.Add(dr);
        
        //or call a function with it
        //SomeFunc(dr);
    }
