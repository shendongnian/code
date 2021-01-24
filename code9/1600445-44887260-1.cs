    public static void Register(HttpConfiguration config)
	{
		//trace provider
		var traceWriter = new SystemDiagnosticsTraceWriter()
		{
			IsVerbose = true
		};
		config.Services.Replace(typeof(ITraceWriter), traceWriter);
		config.EnableSystemDiagnosticsTracing();
		//Web API throttling handler
		config.MessageHandlers.Add(new CustomThrottlingHandler(
			policy: new ThrottlePolicy(perMinute: 20, perHour: 30, perDay: 35, perWeek: 3000)
			{
				//scope to IPs
				IpThrottling = true,
				
				//scope to clients
				ClientThrottling = true,
				ClientRules = new Dictionary<string, RateLimits>
				{ 
					{ "api-client-key-1", new RateLimits { PerMinute = 60, PerHour = 600 } },
					{ "api-client-key-2", new RateLimits { PerDay = 5000 } }
				},
				//scope to endpoints
				EndpointThrottling = true
			},
			
			//replace with PolicyMemoryCacheRepository for Owin self-host
			policyRepository: new PolicyCacheRepository(),
			
			//replace with MemoryCacheRepository for Owin self-host
			repository: new CacheRepository(),
			
			logger: new TracingThrottleLogger(traceWriter)));
	}
