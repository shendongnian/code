    [Route("api/areas")]
    public class AreasController : Controller {
        private IAreaRepository _areaRepository;
        private ILogger<AreasController> _logger;
        private IMapper mapper;
        // Constructor.
        public AreasController(
            IAreaRepository areaRepository,
            ILogger<AreasController> logger,
            IMapper mapper
        ) {
            _areaRepository = areaRepository;
            _logger = logger;
            this.mapper = mapper;
        }
        [HttpGet()]
        public IActionResult GetAreas() {
            try {
                _logger.LogTrace("AreasController.GetAreas called.");
                // Create an IEnumerable of Area objects by calling the repository.
                var areasFromRepo = _areaRepository.GetAreas();
                var areas = mapper.Map<IEnumerable<AreaDto>>(areasFromRepo);
                // Return a code 200 'OK' along with an IEnumerable of AreaDto objects mapped from the Area entities.
                return Ok(areas);
            } catch (Exception ex) {
                _logger.LogError($"Failed to get all Areas: {ex}");
                return BadRequest("Error Occurred");
            }
        }
        //...
    }
