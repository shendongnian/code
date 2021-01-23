    public class BaseController : Controller { 
           protected ILogger Logger {get;} 
           public BaseController(){ 
                Logger = Kernel.Get<ILogger>(); 
           } 
    }
