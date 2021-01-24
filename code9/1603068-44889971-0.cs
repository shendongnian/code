    public long addMachine(machines machinetosave)
    {
	string myconnstr = "server=192.168.0.103;uid=root;pwd=ganga10lfc;database=readingmeterdb";
        try
        {
            MySql.Data.MySqlClient.MySqlConnection() conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myconnstr;
            conn.Open();
	    String sqlstr = "INSERT INTO machines (machineDesc) VALUES ('" + machinetosave.MachineDesc + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlstr,conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
        }
        
    }
