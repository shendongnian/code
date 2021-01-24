    public class SomeController : Controller {
        private readonly ISimRepository simRepository;
        public SomeController(ISimRepository simRepository) {
            this.simRepository = simRepository;
        }
    
        public IActionResult SomeAction() {
            simRepository.LatheIn();
            return Ok();
        }
    }
