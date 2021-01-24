    public static GetExample(string query, params SqlParameter[] parameters)
    {
         if(parameters != null)
              if(parameters.Any())
                   command.Parameters.Add(parameters);
    }
