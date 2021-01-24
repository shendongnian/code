    string masterdb_ConnectionString = string.Format(@"Data Source={0};Initial Catalog=Master;Connect Timeout=79;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Integrated Security=True;", System.Environment.MachineName);
                            
    using (SqlConnection masterdbConn = new SqlConnection())
    {
        masterdbConn.ConnectionString = mastedb_rConnectionString;
        masterdbConn.Open();
                                
        using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
        {
            multiuser_rollback_dbcomm.Connection = masterdbConn;
            multiuser_rollback_dbcomm.CommandText= @"ALTER DATABASE yourdbname SET MULTI_USER WITH ROLLBACK IMMEDIATE";
            multiuser_rollback_dbcomm.CommandTimeout = 79;
                                    
            multiuser_rollback_dbcomm.ExecuteNonQuery();
        }
        masterdbConn.Close();
    }
    SqlConnection.ClearAllPools();
    string yourdb_ConnectionString= "connectionstring for yourdb here";
    using (SqlConnection backupConn = new SqlConnection())
    {
        backupConn.ConnectionString = yourdb_ConnectionString;
        backupConn.Open();
        using (SqlCommand backupcomm = new SqlCommand())
        {
            backupcomm.Connection = backupConn;
            backupcomm.CommandText = string.Format(@"BACKUP DATABASE yourdbname TO DISK='c:\yourdbname.bak'", DateTime.Today.ToString("yyyy/MM/dd"));
            backupcomm.CommandTimeout = 79;
            backupcomm.ExecuteNonQuery();
        }
        backupConn.Close();
    }
