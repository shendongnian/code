    try
                    {
                      var dt = new DataTable();
                      var cmd = new SqlCommand();
                      cmd.CommandText = @"Select Vehicle_Number from [dbo].[Vehicle_Status] Where Status = 'Inactive'";
                                       var da = new SqlDataAdapter(cmd);
                      da.Fill(dt);
                    }
                 catch (Exception ex)
                    {
    
                    }
                 finally
                    {
                      if (cmd.Connection.State == ConnectionState.Open)
                       {
                         cmd.Connection.Close();
                       }
                    }
    
                   var vehicleActive= dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
