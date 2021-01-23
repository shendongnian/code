    private T GetValue<T>(string tableName, colName)
    {
       string query = String.Format("SELECT myColName FROM myTable where myTableName = {0}",  tableName);
       T result = default(T);
       try
       {
           using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString))
             {
              con.Open();
              using (SqlCommand command = new SqlCommand(query, con))
              {
                 result = (T)command.ExecuteScalar();
              }
             }
        }
        catch (SqlException ex)
        {
             Console.WriteLine(ex.Message);
        }
     return result;
    }
