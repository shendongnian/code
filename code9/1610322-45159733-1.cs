    public string GetValueFromDB(string strQuery)
        {
            string strData = "";
            try
            {
                if (m_mySqlConnection == null)
                    OpenDatabase();
                if (string.IsNullOrEmpty(strQuery) == true)
                    return string.Empty;
                MySqlCommand cmd = new MySqlCommand(strQuery, m_mySqlConnection);
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
                if (strData == null)
                    return string.Empty;
                else
                    return strData;
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
                CloseDatabase();
            }
        }
     
