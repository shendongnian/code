                using (DbCommand sqlCommand = sqlConnection.CreateCommand(query))
                {
                    foreach (var parameter in parameters)
                    {
                      //For this I have an ExtensionMethod
                      sqlCommand.AddWithValue(parameter.Key, parameter.Value);
                    }
                    sqlConnection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();
                      
                
            }
        }
    }
