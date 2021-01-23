    public async Task<InfluxResult<UserRow>> TestAsync() {
        var client = new InfluxClient(new Uri("http://localhost:8086"));
        var users = await client.ShowUsersAsync();
        return users;
    }
