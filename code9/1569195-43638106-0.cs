    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddScoped<IDbConnection>(provider => new SqlConnection(Configuration["ConnectionStrings:DevConnection"]));
        // Register the Swagger generator, defining one or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        });
        services.AddMvc();
        services.AddTransient<IGetEventsListQuery, GetEventsListQuery>();
        // Register your database service
        services.AddScoped<IDatabaseService, DatabaseService>();
    }
    public class DatabaseService : IDatabaseService
    {
        public void InsertEvent(Event @event)
        {
            throw new NotImplementedException();
        }
        public void UpdateEvent(Event @event)
        {
            throw new NotImplementedException();
        }
        public void DeleteEvent(long recordId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Event> SelectEventsForList()
        {
            _dbConnection.Query<Event>("SELECT * FROM Event");
        }
        public DatabaseService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        private readonly IDbConnection _dbConnection;
    }
