    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    	.AddJwtBearer(options =>
    	{
    		// base-address of your identityserver
    		options.Authority = Configuration["Authority"]; ;
    
    		// name of the API resource
    		options.Audience = "myAudience";
    		
    		options.Events = new JwtBearerEvents
    		{
    			OnAuthenticationFailed = context =>
    			{
    				//Log failed authentications
    				return Task.CompletedTask;
    			},
    			OnTokenValidated = context =>
    			{
    				//Log successful authentications
    				return Task.CompletedTask;
    			}
    		};
    		
    	});
