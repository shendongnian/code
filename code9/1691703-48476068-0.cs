	public static IIdentityServerBuilder AddCustomCorsPolicy(this IIdentityServerBuilder builder)
	{
		var existingCors = builder.Services.Where(x => x.ServiceType == typeof(ICorsPolicyService)).LastOrDefault();
		if (existingCors != null &&
			existingCors.ImplementationType == typeof(DefaultCorsPolicyService) &&
			existingCors.Lifetime == ServiceLifetime.Transient)
		{
			builder.Services.AddTransient<ICorsPolicyService, CustomCorsPolicyService>();
		}
		return builder;
	}
