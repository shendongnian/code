    private T GetValue<T>(string tableName, colName)
    {
       string query = String.Format("SELECT {0} FROM myTable where myTableName = {1}", colName, tableName);
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
