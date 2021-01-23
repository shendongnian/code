    public class TestFixture {
        public SqliteConnection ConnectionFactory() => new SqliteConnection("DataSource=:memory:");
        public DbContextOptions<ApplicationDbContext> DbOptionsFactory(SqliteConnection connection) =>
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;
        public Company CompanyFactory() => new Company {Name = Guid.NewGuid().ToString()};
        public void RunWithDatabase(
            Action<ApplicationDbContext> arrange,
            Func<ApplicationDbContext, IActionResult> act,
            Action<IActionResult> assert)
        {
            var connection = ConnectionFactory();
            connection.Open();
            try
            {
                var options = DbOptionsFactory(connection);
                using (var context = new ApplicationDbContext(options))
                {
                    context.Database.EnsureCreated();
                    // Arrange
                    arrange?.Invoke(context);
                }
                using (var context = new ApplicationDbContext(options))
                {
                    // Act (and pass result into assert)
                    var result = act.Invoke(context);
                    // Assert
                    assert.Invoke(result);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        ...
    }
