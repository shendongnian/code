    using (SqlConnection masterdbConn = new SqlConnection())
    {
         masterdbConn.ConnectionString = localmasterConnectionString;
         masterdbConn.Open();
          using (SqlCommand rollback_dbcomm = new SqlCommand())
          {
               rollback_dbcomm.Connection = masterdbConn;
               rollback_dbcomm.CommandText = "ALTER DATABASE mydbname SET MULTI_USER WITH ROLLBACK IMMEDIATE";
               rollback_dbcomm.ExecuteNonQuery();
          }
          masterdbConn.Close();
    }
    SqlConnection.ClearAllPools();
    using (SqlConnection backupConn = new SqlConnection())
    {
         backupConn.ConnectionString = localConnectionString;
         backupConn.Open();
         using (SqlCommand backupcomm = backupConn.CreateCommand())
         {
              backupcomm.CommandText = @"BACKUP DATABASE mydbname TO DISK='c:\mydbname.bak'";
              backupcomm.ExecuteNonQuery();
         }
         backupConn.Close();
     }
