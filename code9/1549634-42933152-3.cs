csharp
services.Configure<SecurityHeaderOptions>(options => Configuration.GetSection("SecurityHeaderOptions").Bind(options));
**2.** I believe that the correct registration I refer above returns what you are expecting.
**3.** Just registering it and placing it on the `SecurityHeaderBuilder` constructor is enough. You do not need (neither does the default .NET Core IOC container allows) to pass constructor parameters when registering it. For that you would need to use other IOC's such as Autofac.
But you need to register `SecurityHeadersBuilder` in order to use it within other classes.
Just use an interface for that.
csharp
public interface ISecurityHeadersBuilder
{
	SecurityHeadersBuilder AddDefaultPolicy;    
}
public class SecurityHeadersBuilder : ISecurityHeadersBuilder
{
	private readonly SecurityHeaderOptions _options = null;
	public SecurityHeadersBuilder(IOptions<SecurityHeaderOptions> options)
	{
		_options = options.Value;    
	}
	public SecurityHeadersBuilder AddDefaultPolicy()
	{
		AddFrameOptions();
		AddContentSecurityPolicy();
		return this;
	}
}
Then, just register it in `startup.cs` as this
csharp
services.AddScoped<ISecurityHeadersBuilder, SecurityHeadersBuilder>();
