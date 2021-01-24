    [Produces("application/json")]
    [Route("api/Gebruikers")]//route prefix for this controller
    public class GebruikersController : Controller {
        //...code removed for brevity
        // GET: api/Gebruikers
        [HttpGet]
        public IEnumerable<Gebruiker> GetGebruiker() {
            //...code removed for brevity
        }
    
        // GET: api/Gebruikers/5
        [HttpGet("{id:int}")] // Note the route constraint
        public async Task<IActionResult> GetGebruiker([FromRoute] int id) {
            //...code removed for brevity
        }
    
        // POST: api/Gebruikers/login
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginModel login) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
    
            if(GebruikerVerify(login.email, login.password)) {
                //...code removed for brevity
            } else {
                return BadRequest("invalid data");
            }
        }
    
        // PUT: api/Gebruikers/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutGebruiker([FromRoute] int id, [FromBody] Gebruiker gebruiker) {
            //...code removed for brevity
        }
    
        // POST: api/Gebruikers
        [HttpPost]
        public async Task<IActionResult> PostGebruiker([FromBody] Gebruiker gebruiker) {
            //...code removed for brevity
        }
    
        // DELETE: api/Gebruikers/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGebruiker([FromRoute] int id) {
            //...code removed for brevity
        }
 
        //..code removed for brevity
    }
