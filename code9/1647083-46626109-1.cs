    T Execute<T>(string sql, CommandType commandType, Func<NpgsqlCommand, T> function, List<NpgsqlParameter> parameters)
        {
            using (NpgsqlConnection conn = Konekcija_na_server.Spajanje("spoji")) 
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.CommandType = commandType; 
                    if (parameters.Count > 0 ) 
                    {
                        foreach (var parameter in parameters) 
                        {
                            cmd.Parameters.AddWithValue(parameter.ParameterName,parameter.Value); 
                        }
                    }
                    Konekcija_na_server.Spajanje("prekini");
                    return function(cmd); 
                }
    
            }
    
        }
