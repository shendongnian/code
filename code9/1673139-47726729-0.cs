    using (var cmd = new SQLiteCommand("SELECT IsRented FROM Movies WHERE MoveID LIKE @ID", conn))
    {
        cmd.Parameters.AddWithValue("@ID", movieid);
        using (var reader = cmd.ExecuteReader())
        {
            if (!reader.Read())
            {
                // movie not found
            }
            else if (reader.GetBoolean(0))
            {
                // is rented
            }
            else
            {
                // not yet rented
            }
        }
    }
