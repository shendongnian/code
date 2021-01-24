    private string GetValueFromDBUsing(string strQuery)
        {
            string strData = "";
            try
            {                
                if (string.IsNullOrEmpty(strQuery) == true)
                    return string.Empty;
                using (var mysqlconnection = new MySqlConnection(m_strMySQLConnectionString))
                {
                    mysqlconnection.Open();
                    using (MySqlCommand cmd = mysqlconnection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = strQuery;
                        object objValue = cmd.ExecuteScalar();
                        if (objValue == null)
                        {
                            cmd.Dispose();
                            return string.Empty;
                        }
                        else
                        {
                            strData = (string)cmd.ExecuteScalar();
                            cmd.Dispose();
                        }
                        mysqlconnection.Close();
                        if (strData == null)
                            return string.Empty;
                        else
                            return strData;                        
                    }                    
                }                                
            }
            catch (MySqlException ex)
            {
                LogException(ex);
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return string.Empty;
            }
            finally
            {
                
            }
        }
