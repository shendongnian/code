    string master_ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=Master;Integrated Security=True;Connect Timeout=30;";
    using (SqlConnection masterdbConn = new SqlConnection())
    {
         masterdbConn.ConnectionString = master_ConnectionString;
         masterdbConn.Open();
                                
         using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
         {
             multiuser_rollback_dbcomm.Connection = masterdbConn;
             multiuser_rollback_dbcomm.CommandText= @"ALTER DATABASE yourdbname SET MULTI_USER WITH ROLLBACK IMMEDIATE";
             multiuser_rollback_dbcomm.ExecuteNonQuery();
         }
         masterdbConn.Close();
    }
    SqlConnection.ClearAllPools();
                            
    using (SqlConnection backupConn = new SqlConnection())
    {
        backupConn.ConnectionString = yourConnectionString;
        backupConn.Open();
        using (SqlCommand backupcomm = new SqlCommand())
        {
            backupcomm.Connection = backupConn;
            backupcomm.CommandText= @"BACKUP DATABASE yourdbname TO DISK='c:\yourdbname.bak'";
            backupcomm.ExecuteNonQuery();
        }
        backupConn.Close();
    }
