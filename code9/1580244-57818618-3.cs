    /// <summary>
    /// Customized service behavior for service types. If services are designed as WCF service
    /// All services should have this attribute
    /// </summary>
    public class BaseServiceBehavior : Attribute, IServiceBehavior
    {
    
    	public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    	{
    		BaseServiceInspector baseServiceInspector = new BaseServiceInspector();
    		foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
    		{
    			foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
    			{
    				endpointDispatcher.DispatchRuntime.MessageInspectors.Add(baseServiceInspector);
    
    				foreach (var operation in endpointDispatcher.DispatchRuntime.Operations)
    				{
    					operation.ParameterInspectors.Add(baseServiceInspector);
    				}
    			}
    		}
    	}
    }
