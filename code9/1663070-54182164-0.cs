csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    var connection = Configuration.GetConnectionString("MyConnectionString");
    services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));
}
You need to add this-
json
"ConnectionStrings": {
    "MyConnectionString": ""
}
And the publish tool will looking for `MyConnectionString`, and will find our registration of `DbContext` as service with `MyConnectionString`.
