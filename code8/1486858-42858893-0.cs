    public void Configure(
		IApplicationBuilder app,
		// ... various other parameters that you may have and below add the context that you want to run Migrations
		YourDbContext db1)
    {
    {
        // run the migrations before other code
        db1.Database.Migrate();
		// ...
	}
