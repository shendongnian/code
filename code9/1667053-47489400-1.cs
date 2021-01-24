    public sealed class SnakeCaseNamingAttribute : Attribute, IControllerConfiguration
    {
    	public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
    	{
    		controllerSettings.Formatters.Insert(0, new SnakeCaseJsonFormatter());
    	}
    }
