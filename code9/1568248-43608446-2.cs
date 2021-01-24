       public class ContractController : Controller
        {
            private readonly IPropertiesRepo PropertiesRepo;
            private readonly SurveyEntities db;
            public ContractController(SurveyEntities _db,IPropertiesRepo repo)
            {
                this.db = _db;
                this.PropertiesRepo = repo;
            }
    
            [HttpGet("getall")]
            public JsonResult GetContracts()
            {
                var contracts = this.PropertiesRepo.GetAllLiveContracts().ToList();
                return this.Json(contracts);
            }
        }
