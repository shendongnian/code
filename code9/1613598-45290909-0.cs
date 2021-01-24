    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
    	while (!rdr.IsClosed())
    	{	
    		while (rdr.Read())
    		{
    			Console.WriteLine(rdr.GetValue(0).ToString());
    		}
    		
    		if (!rdr.NextResult())
    		{
    			rdr.Close();
    		}
        }
    }
