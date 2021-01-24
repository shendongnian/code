`
public void ConfigureServices(IServiceCollection services)
{
    ...
    Action<DbContextOptionsBuilder> dbOptionsContextBuilder = builder => 
        {
        builder.UseSqlServer(Configuration.DbConnection)
               .UseLoggerFactory(ConsoleLoggerFactory);   // Logs out SQL
        };
    services.AddDbContext<OpsAutoRepository>(dbOptionsContextBuilder);
    ...
}
`
