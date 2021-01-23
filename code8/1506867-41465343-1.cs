    [Route("api/[controller]")]
    public class ThingsController : Controller
    {
        // GET api/things
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
        }
    
        // GET api/things/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var thingFromDB = await GetThingFromDBAsync();
            if (thingFromDB == null)
                return NotFound();
    
            // Process thingFromDB, blah blah blah
            return Ok(thing); // This will be JSON by default
        }
    
        // POST api/things
        [HttpPost]
        public void Post([FromBody] Thing thing)
        {
        }
    }
