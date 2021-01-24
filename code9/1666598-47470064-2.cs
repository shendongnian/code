    async Task<IQueryable<MyData>> FetchDataAsync(myParams)
    {
        using (SqlConnection dbConnection = new SqlConnection(...)
        {
            // open the connection, don't wait yet:
            Task taskOpen = sqlCommand.OpenAsync();
            // continue while opening:
            using (var sqlCommand = new SqlCommand(...))
            {
                cmd.Parameters.AddWithValue(...);
                // before executing the query: wait until OpenAsync finished:
                await taskOpen;
                // read the data. If nothing to do: await, otherwise use Task similar to Open
                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                foreach (var row in dataReader)
                { 
                    ... (some Await with GetFieldValueAsync
                }
            }
        }
    }
