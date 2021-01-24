csharp
// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();            
}
// Startup.cs
public class Startup
{
    public IHostingEnvironment HostingEnvironment { get; private set; }
    public IConfiguration Configuration { get; private set; }
    public Startup(IConfiguration configuration, IHostingEnvironment env)
    {
        this.HostingEnvironment = env;
        this.Configuration = configuration;
    }
}
## .NET Core 1.x ##
You need to tell `Startup` to load the appsettings files.
csharp
// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .Build();
        host.Run();
    }
}
//Startup.cs
public class Startup
{
    public IConfigurationRoot Configuration { get; private set; }
    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        this.Configuration = builder.Build();
    }
    ...
}
<br />
# Getting Values #
There are many ways you can get the value you configure from the app settings:
 - Simple way using `ConfigurationBuilder.GetValue<T>`
 - Using *[Options Pattern][1]*
Let's say your `appsettings.json` looks like this:
json
{
    "ConnectionStrings": {
        ...
    },
    "AppIdentitySettings": {
        "User": {
            "RequireUniqueEmail": true
        },
        "Password": {
            "RequiredLength": 6,
            "RequireLowercase": true,
            "RequireUppercase": true,
            "RequireDigit": true,
            "RequireNonAlphanumeric": true
        },
        "Lockout": {
            "AllowedForNewUsers": true,
            "DefaultLockoutTimeSpanInMins": 30,
            "MaxFailedAccessAttempts": 5
        }
    },
    "Recaptcha": { 
        ...
    },
    ...
}
## Simple Way ##
You can inject the whole configuration into the constructor of your controller/class (via `IConfiguration`) and get the value you want with a specified key:
csharp
public class AccountController : Controller
{
    private readonly IConfiguration _config;
    public AccountController(IConfiguration config)
    {
        _config = config;
    }
    [AllowAnonymous]
    public IActionResult ResetPassword(int userId, string code)
    {
        var vm = new ResetPasswordViewModel
        {
            PasswordRequiredLength = _config.GetValue<int>(
                "AppIdentitySettings:Password:RequiredLength"),
            RequireUppercase = _config.GetValue<bool>(
                "AppIdentitySettings:Password:RequireUppercase")
        };
        return View(vm);
    }
}
## Options Pattern ##
The `ConfigurationBuilder.GetValue<T>` works great if you only need one or two values from the app settings. But if you want to get multiple values from the app settings, it might be easier to use *Options Pattern*. The options pattern uses classes to represent the hierarchy/structure. 
To use options pattern:
1. Define classes to represent the structure
2. Register the configuration instance which those classes bind against
3. Inject `IOptions<T>` into the constructor of the controller/class you want to get values on
### 1. Define configuration classes to represent the structure ###
You can define classes with properties that **need to exactly match** the keys in your app settings. The name of the class does't have to match the name of the section in the app settings:
csharp
public class AppIdentitySettings
{
    public UserSettings User { get; set; }
    public PasswordSettings Password { get; set; }
    public LockoutSettings Lockout { get; set; }
}
public class UserSettings
{
    public bool RequireUniqueEmail { get; set; }
}
public class PasswordSettings
{
    public int RequiredLength { get; set; }
    public bool RequireLowercase { get; set; }
    public bool RequireUppercase { get; set; }
    public bool RequireDigit { get; set; }
    public bool RequireNonAlphanumeric { get; set; }
}
public class LockoutSettings
{
    public bool AllowedForNewUsers { get; set; }
    public int DefaultLockoutTimeSpanInMins { get; set; }
    public int MaxFailedAccessAttempts { get; set; }
}
### 2. Register the configuration instance ###
And then you need to register this configuration instance in `ConfigureServices()` in the start up:
csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    var identitySettingsSection = _configuration.GetSection("AppIdentitySettings");
    services.Configure<AppIdentitySettings>(identitySettingsSection);
    ...
}
### 3. Inject IOptions<T> ###
Lastly on the controller/class you want to get the values, you need to inject `IOptions<AppIdentitySettings>` through constructor:
csharp
public class AccountController : Controller
{
    private readonly AppIdentitySettings _appIdentitySettings;
    public AccountController(IOptions<AppIdentitySettings> appIdentitySettingsAccessor)
    {
        _appIdentitySettings = appIdentitySettingsAccessor.Value;
    }
    [AllowAnonymous]
    public IActionResult ResetPassword(int userId, string code)
    {
        var vm = new ResetPasswordViewModel
        {
            PasswordRequiredLength = _appIdentitySettings.Password.RequiredLength,
            RequireUppercase = _appIdentitySettings.Password.RequireUppercase
        };
        return View(vm);
    }
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2
