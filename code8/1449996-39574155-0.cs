    class Program
    {
        private static SqlConnection _connection;
        private static SqlTransaction _transaction;
        private static ArrayList array;
        
        
        static void Main(string[] args)
        {
              _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConfig"].ConnectionString);
              try
              {
                  using (_connection)
                  {
					  string finalId = "Something new...";
                      var command = _connection.CreateCommand();
                      command.CommandText = "your query";
                      _connection.Open();
                      array = new ArrayList();
                      using (var reader = command.ExecuteReader())
                      {
                          var indexOfColumn3 = reader.GetOrdinal("IDExtObject");
                          while (reader.Read())
                          {
                              var extId = reader.GetValue(indexOfColumn3).ToString();
                              array.Add(extId);
                          }
                      }
                      foreach (string id in array)
                      {
							
                          UpdateIdSqlTransaction(id, finalId);
                         
                      }
                  }
              }
              catch (Exception)
              {
              }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
            
            Console.ReadLine();
        }
        private static void UpdateIdSqlTransaction(string objectId, string newId)
        {
           try
              {
                  if (_connection.State == ConnectionState.Closed)
                  {
                      _connection.Open();
                  }
                SqlCommand command = _connection.CreateCommand();
                command.Connection = _connection;
                _transaction = _connection.BeginTransaction("UpdateTransaction");
                command.Transaction = _transaction;
                var commandText = "your update statement";
                command.CommandText = commandText;
                command.Parameters.AddWithValue("@ID", objectId);
                command.Parameters.AddWithValue("@newId", newId);
                command.ExecuteNonQuery();
                _transaction.Commit();
             }
             catch (Exception)
                            {
                                _transaction.Rollback();
                            }
              finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
                                
        }
    }
