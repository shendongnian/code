    static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Item1", typeof(string));
            table.Columns.Add("Item2", typeof(string));
            table.Columns.Add("Item3", typeof(string));
            table.Columns.Add("Item4", typeof(string));
            // Here we add five DataRows.
            table.Rows.Add("a", "as", "asd", "");
            table.Rows.Add("b", "asd", "asd", "");
            table.Rows.Add("c", "a", "asd", "");
            table.Rows.Add("d", "a", "asd", "");
            table.Rows.Add("", "", "", "a");
            table.Rows.Add("", "", "", "d");
            table.Rows.Add("", "", "", "asd");
            return table;
        }
        DataTable dt = GetTable();
        foreach (DataRow dr in dt.Rows)
        {
            if (!String.IsNullOrEmpty(dr["Item4"].ToString()) && String.IsNullOrEmpty(dr["Item1"].ToString()))
            {
                dr["Item1"] = dr["Item4"].ToString(); //assign value of column 4 to column1 
            }
        }
        dt.Columns.Remove("Item4"); //delete column 4
    
