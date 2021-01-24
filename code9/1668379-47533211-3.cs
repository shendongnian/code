    public class Startup
    {
    	public Startup(IConfiguration configuration)
    	{
    		Configuration = configuration;
    	}
    
    	public IConfiguration Configuration { get; set; }
    
    	public void ConfigureServices(IServiceCollection services)
    	{
    		//Mvc
    		services.AddMvc();
    
    		//...
    
    		//Authentication
    		services.AddAuthentication()
    			.AddJwtBearer(jwt =>
    			{
    				var signingKey =
    					new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Secret:Key").Value));
    
    				jwt.TokenValidationParameters = new TokenValidationParameters
    				{
    					ValidateIssuerSigningKey = true,
    					IssuerSigningKey = signingKey,
    
    					ValidateIssuer = true,
    					ValidIssuer = "2CIssuer",
    
    					ValidateAudience = true,
    					ValidAudience = "2CAudience",
    
    					ValidateLifetime = true,
    
    					ClockSkew = TimeSpan.Zero
    				};
    			});
    
    		//Authorization
    		services.AddAuthorization(auth =>
    		{
    			auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
    		});
    	}
    
    	public void Configure(IApplicationBuilder app)
    	{
    		//...
    
    		//Authentication
    		var signingKey =
    			new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Secret:Key").Value));
    
    		var options = new TokenProviderOptions
    		{
    			Audience = "2CAudience",
    			Issuer = "2CIssuer",
    			SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
    		};
    
    		app.UseAuthentication();
    
    		//JWT
    		app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
    
    		//Mvc
    		app.UseMvc();
    	}
    }
