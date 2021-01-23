    public class CustomEFDesignTimeServices : IDesignTimeServices
    {
    	//Used for scaffolding database to code
    	public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    	{
    		serviceCollection.AddSingleton<ICSharpUtilities, MyCSharpUtilities>();
    		serviceCollection.AddSingleton<ICSharpEntityTypeGenerator, MyEntityTypeGenerator>();
    	}
    }
