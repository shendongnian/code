    MySqlConnection sqlConnection1 = new MySqlConnection("server=server;uid=username;" + "pwd=password;database=database;");
    MySqlCommand cmd = new MySqlCommand();
    MySqlDataReader reader;
    cmd.CommandText = "SELECT * FROM table";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    sqlConnection1.Open();
    reader = cmd.ExecuteReader();
    try
    {
     reader.Read();
     value = reader.GetString(x);
    }
    finally
    {
     reader.Close();
    } 
