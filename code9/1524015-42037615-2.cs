    void ConfigureServices(IServiceCollection service) {
       services.AddAuthorization(options =>
    	{
            // Here I stored necessary permissions/roles in a constant
    	    foreach (var prop in typeof(ClaimPermission).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
    	    {
    	        options.AddPolicy(prop.GetValue(null).ToString(), policy => policy.RequireClaim(ClaimType.Permission, prop.GetValue(null).ToString()));
    	    }
    	});
    }
