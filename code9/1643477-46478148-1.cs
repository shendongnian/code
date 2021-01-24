    public class ParticipantQuery {
        public string participantId { get; set; } 
        public string participantType { get; set; }
        public string programName { get; set; }
    }
    [Route("api/[controller]")]
    public class TermsController : Controller {
    
        [HttpGet("participants")]  //GET api/terms/participants?participantId=123&....
        [ActionName(nameof(GetByParticipant))]
        public async Task<IActionResult> GetByParticipant([FromQuery]ParticipantQuery model) {
            //...
        }
        
        [HttpGet("programs/{programName}")]//GET api/terms/programs/name
        [ActionName(nameof(GetByProgram))]
        public async Task<IActionResult> GetByProgram(string programName) {
            //...
        }
    }
