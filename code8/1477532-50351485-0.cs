System.IO.StreamReader sr = new System.IO.StreamReader(HttpContextAccessor.HttpContext.Request.Body);
JObject asObj = JObject.Parse(sr.ReadToEnd());
*More* -- An attempt at a concise, non-compiling, example of the items you'll need to ensure are in place in order to get at a useable `IHttpContextAccessor`.
Answers have pointed out correctly that you'll need to seek back to the start when you try to read the request body. The `CanSeek`, `Position` properties on the request body stream helpful for verifying this.
[.NET Core DI Docs][1]
    // First -- Make the accessor DI available
    //
    // Add an IHttpContextAccessor to your ConfigureServices method, found by default
    // in your Startup.cs file:
    // Extraneous junk removed for some brevity:
    public void ConfigureServices(IServiceCollection services)
    {
        // Typical items found in ConfigureServices:
        services.AddMvc(config => { config.Filters.Add(typeof(ExceptionFilterAttribute)); });
        // ...
        // Add or ensure that an IHttpContextAccessor is available within your Dependency Injection container
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
    // Second -- Inject the accessor
    //
    // Elsewhere in the constructor of a class in which you want
    // to access the incoming Http request, typically 
    // in a controller class of yours:
    public class MyResourceController : Controller
	{
		public ILogger<PricesController> Logger { get; }
		public IHttpContextAccessor HttpContextAccessor { get; }
		public CommandController(
			ILogger<CommandController> logger,
			IHttpContextAccessor httpContextAccessor)
		{
			Logger = logger;
			HttpContextAccessor = httpContextAccessor;
		}
        // ...
        // Lastly -- a typical use 
        [Route("command/resource-a/{id}")]
        [HttpPut]
        public ObjectResult PutUpdate([FromRoute] string id, [FromBody] ModelObject requestModel)
        {
            if (HttpContextAccessor.HttpContext.Request.Body.CanSeek)
            {
                HttpContextAccessor.HttpContext.Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.StreamReader sr = new System.IO.StreamReader(HttpContextAccessor.HttpContext.Request.Body);
                JObject asObj = JObject.Parse(sr.ReadToEnd());
                var keyVal = asObj.ContainsKey("key-a");
            }
        }
    }    
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.0
