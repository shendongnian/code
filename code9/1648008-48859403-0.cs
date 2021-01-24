    public abstract class Controller : ControllerBase, IActionFilter, 
    IAuthenticationFilter, IAuthorizationFilter, IDisposable, IExceptionFilter, 
    IResultFilter, IAsyncController, IController, IAsyncManagerContainer
    {
       public IPrincipal User { get; }
    }
