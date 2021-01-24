	services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
	services.AddDbContext<MyDbContext>(
	        (provider, options) => {
	        	var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
	        	var httpContext = httpContextAccessor.HttpContext;
				// here we have the complete HttpContext
	        	var myHeader = context.Request.Headers["MyHeader"]
	        	var connectionString = GetMyConnectionStringFromHeaderOrWhatever(myHeader);
	        	options.UseSqlServer(connectionString);
	        });
