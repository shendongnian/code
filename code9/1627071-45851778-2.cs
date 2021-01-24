	//using System.IO;
	//using Microsoft.AspNetCore.Builder;
	//using Microsoft.AspNetCore.Hosting;
	//using Microsoft.Extensions.DependencyInjection;
	
	public static void Main(string[] args)
	{
		IWebHost host = new WebHostBuilder()
			.UseKestrel()
			.UseContentRoot(Directory.GetCurrentDirectory())
			.ConfigureServices(services =>
			{
				services.AddMvcCore()
					.AddAuthorization()
					.AddRazorPages();
			})
			.Configure(app =>
			{
				//app.UseExceptionHandler("/error");
				app.UseStaticFiles();
				app.UseMvc();
			})
			.Build();
	
		host.Run();
	}
