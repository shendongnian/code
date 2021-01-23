    using (SqlConnection conn = new SqlConnection(connstring))
    {
        conn.Open();
        StringBuilder query = new StringBuilder();
        for (int i = 1; i <= lParameters.Count; i += 3)
            query.Append($"INSERT INTO[dbo].[TestDB]([ID], [Name], [Age])
                        VALUES({lParameters[i]}, '{lParameters[i + 1]}', {lParameters[i + 2]});");
        using (SqlCommand lCommand = new SqlCommand(query.ToString(), conn))
            lCommand.ExecuteNonQuery();
    }
