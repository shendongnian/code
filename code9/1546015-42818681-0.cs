    string connStr = "Server=server:12345;Database=db;UID=user;PWD=pass;";
    conn = new DB2Connection(connStr);
    conn.Open();
    
    if (conn.IsOpen)
    {
    	Console.WriteLine(conn.ConnectionTimeout);
    	cmd = conn.CreateCommand();
    	cmd.CommandText = "select * from orders";
    	cmd.CommandTimeout = 5;
       
    	DB2DataAdapter adp = new DB2DataAdapter(cmd);
    	DataSet ds = new DataSet();
    	adp.Fill(ds);
    	foreach (DataRow row in ds.Tables[0].Rows){
    		Console.WriteLine(row[0]);
    	}
    }
    conn.Close();
