	public class CustomAppHost : AppHostBase
    {
		private List<Action<IHttpRequest, IHttpResponse, object>> responseFilterActions = null;
		
		public CustomAppHost(serviceType, serviceName, assemblies) : base(serviceName, assemblies)
		{		
			List<ICustomResponseFilter> rfList = GetListOfConfiguredResponseFilters(serviceType); 
			/*In GetListOfConfiguredResponseFilters method, serviceType is taken from config and it determines which site we are in currently and retrieves the configured types explained in above step for that site. We need to use reflection here.*/
            this.responseFilterActions = GetActionsListFromResponseFilters(rfList); 
			/*GetActionsListFromResponseFilters method calls the GetAction method of the filters and generates a list of Action types and returns that list*/
		}
		
		public override void Configure(Funq.Container container)
        {
			// other code ..
			
			EndpointHost.ResponseFilters.AddRange(responseFilterActions);
		}
	}
