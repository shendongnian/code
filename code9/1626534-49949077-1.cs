    services.AddSingleton<IActiveUsersService, ActiveUsersService>();
    services.AddScoped<IMongoDbContext, MongoDbContext>();
    services.AddSingleton(option =>
    {
       var client = new MongoClient(MongoConnectionString.Settings);
       return client.GetDatabase(MongoConnectionString.Database);
    })
    
    public class MongoDbContext : IMongoDbContext
    {
       private readonly IMongoDatabase _database;
    
       public MongoDbContext(IMongoDatabase database)
       {
          _database = database;
       }
    
       public IMongoCollection<T> GetCollection<T>() where T : Entity, new()
       {
          return _database.GetCollection<T>(new T().CollectionName);
       }
    }
    
    public class ActiveUsersService: IActiveUsersService, IDisposable
    {
       private readonly IServiceScope _scope;
    
       public ActiveUsersService(IServiceProvider services)
       {
          _scope = services.BeginScope(); // BeginScope is in Microsoft.Extensions.DependencyInjection
       }
       
       public IEnumerable<Foo> GetFooData()
       {
           using (var context = _scope.ServiceProvider.GetRequiredService<IMongoDbContext>())
           {
               return context.GetCollection<Foo>();
           }
       }
       
       public void Dispose()
       {
           _scope?.Dispose();
       }
    }
