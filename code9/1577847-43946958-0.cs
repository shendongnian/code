    static void UpgradeVevo(string nev)
    {
        var connection = new SqlConnection(connectionString))
        connection.Open(); // try doing this without a using
        SqlCommand command = new SqlCommand("UPDATE Vevok SET Torzsvendeg=@enabled Where Nev=@nev", connection);
        command.Parameters.AddWithValue(@"enabled", 1);
        command.Parameters.AddWithValue(@"nev", "vevo123");
        command.ExecuteNonQuery();
        command.Parameters.Clear(); // always clear after executed
        // close connection when you shut down your application
        connection.Close();
        connection.Dispose();
        
        Console.WriteLine(nev+" mostmár törzsvendég");
    }
