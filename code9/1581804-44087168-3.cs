    public static GetExample(string query, params SqlParameter[] parameters)
    {
         using(var connection = new SqlConnection("YourDbConnection"))
         using(var command = new SqlCommand("YourQuery", connection))
         {
              connection.Open();
              if(parameters != null)
                   if(parameters.Any())
                        command.Parameters.Add(parameters);
              command.ExecuteNonQuery();
         }
    }
