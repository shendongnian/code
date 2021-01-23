    string connection = "datasource = localhost; port = 3306; username = root; password = ****";
    
    string query = "SELECT * FROM databasename.tablename where id=@ID ";
    
    MySqlConnection conn = new MySqlConnection(connection);
    MySqlCommand command = new MySqlCommand(query, conn);
    command.Parameters.Add("@ID",textBox1.Text);
    MySqlDataReader reader;
    conn.Open();
    
    reader = command.ExecuteReader();
    
    while (reader.Read()) {}
