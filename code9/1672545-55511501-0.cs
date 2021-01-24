using Microsoft.Extensions.Logging;
public class HomeController : Controller
{
    ILogger _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _logger.LogInformation("Controller instantiated");
    }
}
For other classes in other projects just make sure you depend on the default ILogger interface, not Serilog's implementation. This also has the benefit that, if you want to replace Serilog later, you can do this without having to remove all references to it throughout your other projects as well. 
using Microsoft.Extensions.Logging;
public class MyBusinessObject
{
    ILogger _logger;
    public MyBusinessObject(ILogger<MyBusinessObject> logger)
    {
        _logger = logger;
    }
    public void DoBusinessLog()
    {
        _logger.Information("Executing Business Logic");
    }
}
For some reason DI only manages to instantiate a Logger instance when requiring an `ILogger<Type>` but not for `ILogger`. Why that is exactly I don't know, maybe someone else can answer that one.
