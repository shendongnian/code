    class MyContext : DbContext
    {
        SqliteConnection _connection;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _connection = new SqliteConnection(_connectionString);
            _connection.Open();
                
            var command = _connection.CreateCommand();
            command.CommandText = "PRAGMA key = 'password';";
            command.ExecuteNonQuery();
            options.UseSqlite(_connection);
        }
        protected override void Dispose()
        {
            _connection?.Dispose();
        }
    }
