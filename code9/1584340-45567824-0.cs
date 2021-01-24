var scopeFactory = ApplicationServices.GetService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetService<CommunicatorDbContext>();
	DbInitializer.Initializer(dbContext, ldapService);
}
Although, as mentioned on Slack, don't do this ;-)
