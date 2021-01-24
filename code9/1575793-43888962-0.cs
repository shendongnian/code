    private async Task WriteMessageToDB(Guid id, string tableName, string jsonString)
        {
                string sql = *Redacted*
                await dbConnection.ExecuteScalarAsync<int>(sql, new { ID = id, Body = jsonString });
        }
