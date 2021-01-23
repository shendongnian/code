    public class TestFixture {
        ...
        public async Task RunWithDatabaseAsync(
            Func<ApplicationDbContext, Task> arrange,
            Func<ApplicationDbContext, Task<IActionResult>> act,
            Action<IActionResult> assert)
        {
            var connection = ConnectionFactory();
            await connection.OpenAsync();
            try
            {
                var options = DbOptionsFactory(connection);
                using (var context = new ApplicationDbContext(options))
                {
                    await context.Database.EnsureCreatedAsync();
                    if (arrange != null) await arrange.Invoke(context);
                }
                using (var context = new ApplicationDbContext(options))
                {
                    var result = await act.Invoke(context);
                    assert.Invoke(result);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
