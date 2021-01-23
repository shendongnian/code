    public bool Insert(string query, byte[] rawImage)
        {
            //open connection
            if (OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
    
                    Parameter parameter = new Parameter("@rawImage", DbType.Binary);
                    parameter.Value = rawImage;
                    cmd.Parameters.Add(parameter);
    
                    cmd.ExecuteNonQuery();
                    return true;
    
                }
                catch
                {
                    return false;
                }
                finally
                {
                    CloseConnection();
                }
    
            }else
            {
    
                return false;
            }
        }
