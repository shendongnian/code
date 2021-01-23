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
                   foreach (var p in OutParameter)
                   {
                        cmd.Parameters.Add(p);
                   }
                   cmd.Connection.Open();
                   affectedRows = cmd.ExecuteNonQuery();
                   foreach (var p in OutParameter)
                   {
                        p.Value = cmd.Parameters[p.ParameterName].Value;
                   }
                   if (affectedRows == 0)
                   {
                            ResultSet = ExecuteNonQueryResult.ZeroRecordSuccess;
                   }
                   else
                   {
                       if (affectedRows > 1)
                       {
                            ResultSet = ExecuteNonQueryResult.ManyRecordSuccess;
                       }
                       else
                       {
                            ResultSet = ExecuteNonQueryResult.OneRecordSuccess;
                       }
                   }
               }
                    catch (Exception InnerEx)
                    {
                        ErrorHandlerBLL.Add_AppException(InnerEx);
                        ResultSet = ExecuteNonQueryResult.Error;
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
