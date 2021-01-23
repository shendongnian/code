    namespace MvcApp.Controllers
    {
    	public class ProductController : Controller
    	{
    		protected ILogger Logger;
    
    		public ProductController(ILogger logger;)
    		{
    			Logger = logger;
    		}
    
    		public ActionResult Index()
    		{
    			Logger.Write(LogEntry.Event, Server.SessionID, "Start of '{0}' action call", "Index");
    
    
    			var serviceStopwatch = Stopwatch.StartNew();
    
    			Logger.Write(LogEntry.Task, Server.SessionID, "Start of '{0}' task's execution", "GetData");
    
    			var data = service.GetData();
    
    			serviceStopwatch.Stop();
    
    			Logger.Write(LogEntry.Task, Server.SessionID, serviceStopwatch.Elapsed, "End of '{0}' task's execution", "GetData");
    
    
    			var dbCallStopwatch = Stopwatch.StartNew();
    
    			Logger.Write(LogEntry.Task, Server.SessionID, "Start of '{0}' db call", "GetObjects");
    
    			var objects = repository.GetObjects();
    
    			dbCallStopwatch.Stop();
    
    			Logger.Write(LogEntry.Task, Server.SessionID, dbCallStopwatch.Elapsed, "End of '{0}' db call", "GetObjects");
    
    
    			Logger.Write(LogEntry.Event, Server.SessionID, "End of '{0}' action call", "Index");
    
    			return View();
    		}
    	}
    }
