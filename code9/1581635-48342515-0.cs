    services.AddDbContext<MyDbContext>(options =>
					{
					options.UseInMemoryDatabase("TestDb");
					options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
					});
