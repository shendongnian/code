    public void Add_writes_to_database()
    {
        // In-memory database only exists while the connection is open
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        try
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseSqlite(connection)
                .Options;
            // Create the schema in the database
            using (var context = new BloggingContext(options))
            {
          
            }
        }
        finally
        {
            connection.Close();
        }
    }
