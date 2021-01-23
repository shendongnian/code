    public static void SqlInject(string query, string dataBase)
    {
       var connectionString = 
         System 
         .Configuration 
         .ConfigurationManager 
         .ConnectionStrings["conProject"] 
         .ConnectionString;
      
      using ( var connection = new SqlConnection( connectionString ) )
      {
        connection.Open( );
        using ( var command = connection.CreateCommand( ) )
        {
          command.CommandText = query;
          command.CommandType = CommandType.Text;
          command.ExecuteNonQuery( );
        }
      }
    }
