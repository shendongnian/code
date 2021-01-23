    public class MyDesignTimeServices : IDesignTimeServices
    {
    	public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    	{
    		serviceCollection.AddSingleton<ICSharpEntityTypeGenerator, MyEntityTypeGenerator>();            
    	}
    }
