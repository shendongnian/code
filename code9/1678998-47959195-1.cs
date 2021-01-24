    using (var conn = new SqlConnection(connString))
    {
    	conn.Open();
    	using (var comm = conn.CreateCommand())
    	{
    		comm.CommandType = CommandType.Text;
    		comm.CommandText = "BACKUP DATABASE...";
    		comm.ExecuteNonQuery();
    	}
    }
