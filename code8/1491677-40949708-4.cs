    public class TestFixture {
        ...
        public async Task RunWithDatabaseAsync(
            Func<ApplicationDbContext, Task<dynamic>> arrange,
            Func<ApplicationDbContext, dynamic, Task<IActionResult>> act,
            Action<IActionResult, dynamic> assert)
        {
            var connection = ConnectionFactory();
            await connection.OpenAsync();
            try
            {
                object data;
                var options = DbOptionsFactory(connection);
                using (var context = new ApplicationDbContext(options))
                {
                    await context.Database.EnsureCreatedAsync();
                    data = arrange != null 
                        ? await arrange?.Invoke(context) 
                        : null;
                }
                using (var context = new ApplicationDbContext(options))
                {
                    var result = await act.Invoke(context, data);
                    assert.Invoke(result, data);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
