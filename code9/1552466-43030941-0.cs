    using (SqlConnection conn = new SqlConnection("..."))
    {
        conn.InfoMessage += (sender, e) =>
        {
            Console.WriteLine($"{e.Source}-{e.Message}");
        };
        conn.Open();
        using (SqlCommand command = new SqlCommand("PRINT 'Hello World'", conn))
        {
            command.ExecuteNonQuery();
        }
    }
