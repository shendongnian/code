    public abstract class BaseController : Controller
    {
        [Dependency]
        public ISystemUserCommand SystemUserCommand { get; set; }
    }
