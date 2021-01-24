    string master_ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=Master;Integrated Security=True;Connect Timeout=30;";
    using (SqlConnection restoreConn = new SqlConnection())
    {
        restoreConn.ConnectionString = master_ConnectionString;
        restoreConn.Open();
        using (SqlCommand restoredb_executioncomm = new SqlCommand())
        {
            restoredb_executioncomm.Connection = restoreConn;
            restoredb_executioncomm.CommandText = @"RESTORE DATABASE yourdbname FROM DISK='c:\yourdbname.bak'";
                                    
            restoredb_executioncomm.ExecuteNonQuery();
        }
        restoreConn.Close();
    }
