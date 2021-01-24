    public class SecuredTaskController : ApiController
    {
        private IContext _context;
        private ITaskService _taskService;
        // other services needed for access check (eg. userService?)
        public SecuredTaskController(ITaskService taskService, IContext context
            // other services needed for access check (eg. userService?)
            )
        {
            _taskService = taskService;
            _context = context;
        }
        public IHttpActionResult Get(Task task)
        {
            if (hasGetAccess(task, _context.UserId))
                return Ok(_taskService.Get(task));
            else
                return Unauthorized();
        }
        private bool hasGetAccess(Task task, long userId)
        {
            // check if userId has acces to get task
        }
    }
