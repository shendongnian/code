    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
    reader = cmd.ExecuteReader();
    
    // Read() will return a bool indicating whether a new row has been read
    // false signals no more data
    while (reader.Read()) {
        // Do something with the row data
        CarN.Text = reader.GetString(reader.GetOrdinal("CarModel"));
    }
    reader.Close();
    conn.Close();
