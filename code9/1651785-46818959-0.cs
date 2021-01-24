    public class CustomJwtBearerEvents : JwtBearerEvents
    {
        AppSessionService _session;
        public CustomJwtBearerEvents(AppSessionService session)
        {
            _session = session;
        }
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            // Add the access_token as a claim, as we may actually need it
            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (Guid.TryParse(accessToken.Id, out Guid sessionId))
            {
                if (await _session.ValidateSessionAsync(sessionId))
                {
                    return;
                }
            }
            throw new SecurityTokenValidationException("Session not valid for provided token.");
        }
    }
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CustomJwtBearerEvents>();
    
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.EventsType = typeof(CustomJwtBearerEvents);
                });
        }
    }
