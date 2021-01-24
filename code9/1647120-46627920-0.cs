    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
	public static IWebHost BuildWebHost(string[] args) => new WebHostBuilder()
            .UseKestrel()
			.Configure(app =>
			{
                // notice how we don't have app.UseMvc()?
				app.Map("/", SayHello);
			})
			.Build();
    private static void SayHello(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            // implement your own response
            await context.Response.WriteAsync("Hello World!");
        });
    }
