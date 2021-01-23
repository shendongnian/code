    public static void SqlInject(string commandName, params[] object commandArgs )
    {
       //--> no point in going on if we got no command...
       if ( string.IsNullOrEmpty( commandName ) )
         throw new ArgumentNullException( nameof( commandName ) );
  
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
          command.CommandType = CommandType.Text;
          command.CommandText = "select commandText from dbo.StatementRepository where commandName = @commandName";
          command.Parameters.AddWithValue( "@commandName", commandName );
          var results = command.ExecuteScalar( );
          if ( results != null && results != DbNull.Value )
          {            
            //--> calling a separate method to validate args, that returns
            //--> an IDictionary<string,object> of parameter names
            //--> and possibly modified arguments.
            //--> Let this validation method throw exceptions.
            var validatedArgs = ValidateArgs( commandName, commandArgs );
            
            command.Parameters.Clear( );
            command.CommandText = query;
            foreach( var kvp in validatedArgs )
            {
              command.Parameters.AddWithValue( kvp.Key, kvp.Value );
            }
            command.ExecuteNonQuery( );
          }
          else
          {
            throw new InvalidOperationException( "Invalid command" );
          }          
        }
      }
    }
