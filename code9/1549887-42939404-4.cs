    [TestMethod]
    public void Foo_DoesBar_WhenBaz()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        try
        {
            var options = new DbContextOptionsBuilder<BloggingContext>()
                .UseSqlite(connection)
                .Options;
            using (var context = new BloggingContext(options))
            {
                ...          
            }
        }
        finally
        {
            connection.Close();
        }
    }
