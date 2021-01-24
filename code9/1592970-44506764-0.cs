    public static class IUnityContainerExt
    {
    	public static IWorkflow ResolveForTenant(this IUnityContainer container, string Name)
    	{
    		IWorkflow workflow;
    		try
    		{
    			workflow = container.Resolve<IWorkflow>("tenant0"); 
    		}
    		catch (ResolutionFailedException e)
    		{
    			//If the resolver can't resolve the name it will throw ResolutionFailedException and you can select the default instead
    			workflow = container.Resolve<IWorkflow>();
    		}
            return workflow;
    	}
    }
