     using ResourceLibrary;
     ...
     public class ExampleController : Controller
        {
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        public EmailsController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }
    
        [HttpGet]
        public string Get()
        {
            return _sharedLocalizer["StringToTranslate"];
        }
