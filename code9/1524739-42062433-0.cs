    public interface IRequestDatabaseLoggerFactory {
        IRequestDatabaseLogger Create(ActionExecutingContext context);
    }
    public class RequestDatabaseLoggerFactory : IRequestDatabaseLoggerFactory {
        public IRequestDatabaseLogger Create(ActionExecutingContext context) {
            return new RequestDatabaseLogger(context);
        }
    }
    public class ActionFilter : ActionFilterAttribute
    {
		public ActionFilter(IRequestDatabaseLoggerFactory factory) {
			_factory = factory;
		}
		
		private readonly IRequestDatabaseLoggerFactory _factory;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requestDatabaseLogger = _factory.Create(context);
            long logId = requestDatabaseLogger.Log();
            context.HttpContext.AddCurrentLogId(logId);
            base.OnActionExecuting(context);
        }
   }
