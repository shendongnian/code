    private async Task ImportArticles()
    {
        ...
        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                // Omitted for brevity
            }
        }
    }
