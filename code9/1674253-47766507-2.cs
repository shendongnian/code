     Private static ... GetData()
               {
                 try
                    {
                      var dt = new DataTable();
                      var cmd = new SqlCommand();
                      cmd.CommandText = @"SELECT name,address FROM [table_name] WHERE id = @id";
                      cmd.Parameters.AddwithValue("@id",id);
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
              
                   var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                   return stringArr;
               }
