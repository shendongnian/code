    public class ContainerRegistry : Registry
    {
    	public ContainerRegistry()
    	{
    		// The Override
    		For(typeof(IRepository<>)).Use(typeof(GenericRepositoryIdentifiableStub<>));
    	} 
    }
