    using (var command = new SqlCommand("SELECT Content FROM Document WHERE ID=1 ORDER BY Sequence", connection))
    using (var reader = command.ExecuteReader())
    {
        // Set a large enough initial capacity
        StringBuilder sb = new StringBuilder(32767);
        while(reader.Read())
        {
            sb.Append(reader.GetString(0));
        }
    }
