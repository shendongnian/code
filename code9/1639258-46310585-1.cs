                using (DbCommand sqlCommand = sqlConnection.CreateCommand(query))
                {
                    foreach (var parameter in parameters)
                    {
                       DbParameter param = sqlCommand.CreateParameter();
                       param.ParameterName= parameter.Key;
                       param.Value=parameter.Value;
                       sqlCommand.Parameters.Add(param );
                    }
                    sqlConnection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();
                      
                
            }
        }
    }
