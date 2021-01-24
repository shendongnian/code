    var datatable = new DataTable(); // take your datatable
    string s = "primaryKeyValue";
    DataRow[] row = datatable.Select("name='" + s + "'");
    for (int i = row.Length - 1; i >= 0; i--)
    {
    	datatable.Rows.Remove(row[i]);
    }
    datatable.AcceptChanges();
    
            
