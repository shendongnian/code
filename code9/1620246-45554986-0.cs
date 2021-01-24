    public class VisitorFormController : ApiController
    {
        private IDataAccessRepository _repository;
        public VisitorFormController(IDataAccessRepository repository): base()
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/VisitorForm/{code}/{pageType}")]
        [EnableCors(origins: "*", headers: "*", methods: "options,get")]
        public async Task<IHttpActionResult> GetFormInfo(string code, string pageType)
        {
           var tracer = Request.GetConfiguration().Services.GetTraceWriter();
           // Use tracer from here on...
        }
    }
