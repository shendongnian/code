    public class HSMController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public string contentRootPath { get; set; }
        public HSMController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootPath = _hostingEnvironment.ContentRootPath;
        }
        [Route("/PingHSM")]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 500)]
        public IActionResult PingHSM()
        {
            IHSM hsm = HSMFactory.GetInstance(contentRootPath);
            return Ok(hsm.PingHSM());
        }
    }
