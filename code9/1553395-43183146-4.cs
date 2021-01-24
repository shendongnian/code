     services.AddTransient<IAuthenticationResolver, AuthenticationResolver>();
                services.AddTransient<WindowsAuthentication>();
                services.AddTransient<KerberosAuthentication>();
                services.AddTransient<NTMLAuthentication>();
                services.AddTransient<CustomAuthentication>();
