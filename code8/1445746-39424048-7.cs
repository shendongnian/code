    try
    {
         using (SqlCommand cmd = new SqlCommand(Query, Connection))
         {
              try
              {
                   cmd.CommandType = CommandType;
                   foreach (var p in InParameters)
                   {
                        cmd.Parameters.Add(p);
                   }
                   cmd.Connection.Open();
                   affectedRows = cmd.ExecuteNonQuery();
                   if (affectedRows == 0)
                   {
                        //Zero Record Success
                   }
                   else
                   {
                       if (affectedRows > 1)
                       {
                            //Many Record Success
                       }
                       else
                       {
                            //One Record Success
                       }
                   }
               }
               catch (Exception InnerEx)
               {
                    //Handle your error
               }
               finally
               {
                   if (cmd.Connection.State != ConnectionState.Closed)
                   {
                       cmd.Connection.Close();
                   }
               }
          }
    }
