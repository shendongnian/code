            using (DbConnection sqlConnection = Activator.CreateInstance(connectionType, new object[] {connectionString}) as DbConnection)
            {
                using (DbCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = query;
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
