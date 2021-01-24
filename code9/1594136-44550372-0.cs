    private IEnumerable<string> UpdateQueries(MySqlConnection connection, List<string> queries)
    {
        foreach (var query in queries)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            command.ExecuteNonQuery();
            yield return query;
        }
    }
