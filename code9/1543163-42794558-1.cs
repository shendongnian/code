    public class RequestController : BaseController
    {
        private readonly IAvailableActionProvider _actionProvider;
        public RequestController(IAvailableActionProvider actionProvider)
        {
            _actionProvider = actionProvider;
        }
        public RequestController() : this(new AvailableActionProvider())
        {
        }
        ...
    }
