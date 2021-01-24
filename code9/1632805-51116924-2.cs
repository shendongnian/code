    public class SwaggerConfig
    {
    	public static void Register()
    	{
    		var thisAssembly = typeof(SwaggerConfig).Assembly;
    
    		GlobalConfiguration.Configuration
    			.EnableSwagger(c =>
    			{
    				c.MultipleApiVersions(
    					(apiDesc, version) =>
    					{
    						var path = apiDesc.RelativePath.Split('/');
    						var pathVersion = path[1];
    
    						return CultureInfo.InvariantCulture.CompareInfo.IndexOf(pathVersion, version, CompareOptions.IgnoreCase) >= 0;
    					},
    					(vc) =>
    					{
    						vc.Version("v2", "Swashbuckle Dummy API V2");
    						vc.Version("v1", "Swashbuckle Dummy API V1");
    					});
    			})
    			.EnableSwaggerUi(c =>
    			{
    				c.EnableDiscoveryUrlSelector();
    			});
    	}
    }
