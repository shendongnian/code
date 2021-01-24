    using (SqlConnection con = new SqlConnection(connectionString))
    {
         // SQL query to get the data from the database
         string sql = @"[query string here]";
         con.Open();
    
         // connecting to the SQL Server
         using (SqlCommand command = new SqlCommand(sql, con))
         {
             SqlParameter[] parameters = new[]
             {
                 new SqlParameter(@"CLCL_CUR_STS", SqlDbType.Int).Value = "01",
                 new SqlParameter(@"CLCL_CL_SUB_TYPE", SqlDbType.VarChar).Value = "M",
                 new SqlParameter(@"CLMD_TYPE", SqlDbType.VarChar).Value = "01",
                 new SqlParameter(@"CLCL_RECD_DT", SqlDbType.DateTime).Value = "2017-02-03 00:00:00.000",
             };
             foreach (SqlParameter sqlParam in parameters)
             {
                 command.Parameters.Add(sqlParam);
             }
             
             // Reading the SQL database
             using (SqlDataReader reader = command.ExecuteReader())
             {
                 // fetch retrieved data
             }
         }
         // other stuff
         con.Close();
    }
