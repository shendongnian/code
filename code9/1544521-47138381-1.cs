    string strConnect = "server=127.0.0.1;uid=user;pwd=password;database=mysql_db_name;Allow User Variables=True";
    Using (MySqlConnection mysqlConnection = new MySqlConnection(strConnect))
    {
        Using (MySqlCommand mysqlCommand = new MySqlCommand())
        {
            mysqlCommand.CommandTimeout = 600;
            mysqlCommand.Connection = mysqlConnection;
            mysqlCommand.CommandType = CommandType.Text;
            mysqlCommand.CommandText = "LOAD DATA INFILE (...your specific command here)";
            try
            {
                mysqlConnection.Open();
                mysqlCommand.ExecuteNonQuery();
                mysqlConnection.Close();
            }
            catch(Exception ex)
            {
                // handle errors
            }
        }
    }
