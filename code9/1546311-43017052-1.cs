	public void Execute(IServiceProvider serviceProvider)
	{
		var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
		var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
		var crmService = factory.CreateOrganizationService(context.UserId);
		var interceptor = new SFACMessageInspector(crmService);
	}
