    public int ExecuteNonQueryWithOutputParamInt(string spName, Dictionary<string, string> parms, Dictionary<string, object> oParam = null)
            {
                string key = null;
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spName;
    
                    foreach (var para in parms)
                    {
                        cmd.Parameters.AddWithValue(para.Key, para.Value);
                    }
    
    
                    if (oParam != null)
                    {
    
                        foreach (var p in oParam)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value).Direction = ParameterDirection.Output;
                            key = p.Key;
                        }
                    }
                        this.OpenConnection();
                        cmd.ExecuteNonQuery();
                        int returnValue = Convert.ToInt32(cmd.Parameters[key].Value);
                        this.CloseConnection();
                        return returnValue;
    
    
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return 0;
                }
            }
