    private readonly IConfigurationRoot configuration;
    private IDbConnection dbConnection { get; }
    
    public Example(IConfigurationRoot configuration)
    {
         this.Configuration = configuration;
         dbConnection = new SqlConnection(this.configuration.GetConnectionString("..."));
    }
