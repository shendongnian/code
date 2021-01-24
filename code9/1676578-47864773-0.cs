    public class MyActionFilter : IActionFilter
    {
        private readonly MyDbContext _dbContext;
        public MyActionFilter(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // use _dbContext here
        }
        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
