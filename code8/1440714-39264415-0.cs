    string strConn = "server = localhost; user = root; database = ****; port = 3306; password = ****; Charset = utf8";
    using (MySqlConnection conn = new MySqlConnection(strConn))
    {
        MySqlCommand insertCommand = conn.CreateCommand();
    
        conn.Open();
    
        for (int i = 0; i < 10; i++)
        {
            insertCommand.CommandText = "INSERT INTO master (col_name, col_code)" +
            " SELECT * from (select '" + _name[i] + "', '" + _code[i] + "') as tmp" +
            " WHERE NOT EXISTS (" +
            " SELECT col_code FROM master WHERE col_code = '" + _name[i] + "') limit 1;";
    
            insertCommand.ExecuteNonQuery();
        }
        conn.Close();  //you don't need this.
    }
