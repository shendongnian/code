    using (Common.DbCommand cmd = conn.CreateCommand()) {
    	cmd.CommandText = "SELECT * FROM table1";
    	dynamic dr = cmd.ExecuteReader();
    	int index = 0;
    	List<string> columns = new List<string>();
    
    	for (index = 0; index <= dr.FieldCount - 1; index++) {
    
    		columns.Add(dr.GetName(index));
    	}
    
    }
