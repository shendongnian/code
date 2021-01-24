               // somehting with database ....
          }
          catch (SqlException ex)
          {
               AttemptToLogDbError(ex)
               throw new DataException(ex.Message, ex);
          }
          // ...
     }
     void AttemptToLogDbError(SqlException ex)
     {
          try
          {
               //Call Error Management DB Connection and add content to the table
               using (SqlConnection connection = new SqlConnection(_errorManagementConnectionString))
               {
                    connection.open();
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertDataErrors]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InputParam", InputParam);
                    cmd.Parameters.AddWithValue("@Content", Content);
                    cmd.ExecuteNonQuery();
               }
          }
          catch (Exception err)
          {
               // OMG nothing is working at all! log / report this somehow, but do not throw
          }
     }
