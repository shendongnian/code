    NpgsqlConnection conn = new NpgsqlConnection(connectionString);
    conn.Open();
    NpgsqlCommand cmd = new NpgsqlCommand("select arr from test", conn);
    NpgsqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        double[] myArray = (double[])reader.GetValue(0);
        // do your bidding
    }
    reader.Close();
