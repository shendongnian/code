public void ConfigureServices(IServiceCollection services)
{
   services.AddMvc();
   var connection = @"Server=localhost;Port=5432;Database=NewDB;User Id=xxxxx;Password=cr@aaaa;";
   services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
    // ...
}
And the reasons is user is trying to connect to PostgreSQL but did change the default Option UseSQLServer after configuring the PostgreSQL string. 
To fix the issue change the option
***
> options.UseSqlServer(connection)) -> options.UseNpgsql(connection))
***
