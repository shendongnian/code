    // Access Db
    public async Task<object> GetValueFromDatabaseAsync()
    {
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            await connection.OpenAsync();
            return await command.ExecuteScalarAsync();
        }
    }
    // Make web request
    public async Task<HttpResponseMessage> SendRequestToWebServiceAsync(SomeData data)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(webserviceUrl);
            return await client.PostAsJsonAsync("api/values", data);
        }
    } 
