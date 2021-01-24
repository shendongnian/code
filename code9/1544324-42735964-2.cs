    SQLiteDataReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
        Console.WriteLine(reader["month"].ToString());
        Console.WriteLine(reader["sum_amountpaid"].ToString());
    }
    con.Close();
