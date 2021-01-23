    public class SharepointAuthController
    {
        public SharepointAuthController(Repo repo)
        {
            ValidateContext();
            _repo = repo;
        }
        // rest of controller ...
    }
    public class CallPointsController : SharepointAuthController
    {
        private readonly ICallPointRepository _callPointRepository;
        public CallPointsController(ICallPointRepository callPointRepository, Repo repo) 
         : base(repo)
        {
            _callPointRepository = callPointRepository;
        }
    }
    
