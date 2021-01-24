	public class Program {
		public static void Main(string[] args) {
			var host = BuildWebHost(args);
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var logger = services.GetRequiredService<ILoggerFactory>();
				var ctx = services.GetRequiredService<DataContext>();
				// Now I can access the DbContext, create Repository, SeedData, etc!
