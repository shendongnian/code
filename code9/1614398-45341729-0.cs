    public class UnityServiceHost : ServiceHost
    {
    	public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
    		: base(serviceType, baseAddresses)
    	{
    		if (container == null)
    		{
    			throw new ArgumentNullException(nameof(container));
    		}
    		Description.Behaviors.Add(new UnityInstanceProvider(serviceType, container));
    	}
    }
