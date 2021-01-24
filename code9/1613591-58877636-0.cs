    [Route("api/{lang}/[controller]/[Action]")]
        [ApiController]
        public class SpatiaController : ControllerBase
        {
            private readonly ISpatialService _service;
            private readonly ILogger<SpatialController> _logger;
    
            public SpatialUnitsIGMEController(ILogger<SpatialController> logger, ISpatialService service) 
            {
                _service = service;
                _logger = logger;
            }
    
           
            [HttpGet]
            public async Task<ActionResult<IQueryable<ItemDto>>> Get50k(string lang)
            {
                var result = await _service.GetAll50k(lang);
                return Ok(result);
            }
    
            [HttpGet("{name}")]
            public async Task<ActionResult<ItemDto>> Get50k(string lang, string name)
            {
                var result = await _service.Get50k(lang, name);
                return Ok(result);
            }
    	}
