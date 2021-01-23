    string queryOne = "SELECT " + column_name + " FROM log.transactions";
    MySqlCommand cmdOne = new MySqlCommand(queryOne, connectionString);        
    MySqlDataReader dataReaderOne = cmdOne.ExecuteReader();
    while (dataReaderOne.Read())
        {
            Console.WriteLine(dataReaderOne[column_name]);
        }
    dataReaderOne.Close();
