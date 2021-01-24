    public class ValuesController
    {
    	private readonly IDynamoDBContext context;
    
    	public ValuesController(IDynamoDBContext context)
    	{
    		this.context = context;
    	}
    
    	// ...
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
        services.AddAWSService<IAmazonDynamoDB>();
    	services.AddTransient<IDynamoDBContext, DynamoDBContext>();
    }
