    string path = @"C:\";
    using (OleDbConnection conn =
                new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                path + @";Extended Properties=""Text;HDR=No;FMT=Delimited"""))
    {
        using (OleDbCommand cmd =
            new OleDbCommand("SELECT * FROM verylarge.csv", conn))
        {
        	conn.Open();
        
        	using (OleDbDataReader dr =
                cmd.ExecuteReader(CommandBehavior.SequentialAccess))
        	{
        		while (dr.Read())
        		{
        			int test1 = dr.GetInt32(0);
                    int test2 = dr.GetInt32(1);
                    int test3 = dr.GetInt32(2);
                    int test4 = dr.GetInt32(3);
                    int test5 = dr.GetInt32(4);
        		}
        	}
        }
    }
