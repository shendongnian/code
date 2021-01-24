    public static class IoC
    {
    	public static IContainer Initialize()
    	{
    		var container = new Container();
    
    		// NOTE: If you have many Registries to consider, you can add them (order matters)
    		
    		// The Business Registry
    		container.Configure(x => x.AddRegistry<Business.DependencyResolution.ContainerRegistry>());
    		
    		// The UnitTest Projects Registry (order matters)
    		container.Configure(x => x.AddRegistry<ContainerRegistry>());
    
    		return container;
    	} 
    }
