    public class DocumentController : Controller
    {
        IAuthorizationService _authorizationService;
    
        public DocumentController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
    }
