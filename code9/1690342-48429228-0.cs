     DataSet dsPrograms = new DataSet();
     SqlDataAdapter da = new SqlDataAdapter();
     SqlCommand cmdArcResponseHandler = new SqlCommand();
     SqlConnection conn = new SqlConnection(_dbConnection);
     if (conn.State == System.Data.ConnectionState.Closed)
     {
         conn.Open();
     }
     cmdArcResponseHandler.CommandText = @"select * from #temp1;
                                           select * from #temp2;
                                           select * from #temp3;"
     cmdArcResponseHandler.CommandTimeout = 120;
     cmdArcResponseHandler.CommandType = CommandType.Text;
     cmdArcResponseHandler.Connection = conn;
     da.SelectCommand = cmdArcResponseHandler;
     da.Fill(dsPrograms);
     ds.Tables[0].TableName = "Table 1";
     ds.Tables[0].TableName = "Table 2";
     ds.Tables[0].TableName = "Table 3";
