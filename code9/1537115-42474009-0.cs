       [Produces("application/json")]
        [Route("api/start")]
        public class StartController : Controller
        {
            // GET: api/start
            [HttpGet]
            public IActionResult  Get()
            {
                return Json(new {ServerId = "1", ServerPort = "27015"}); 
            }
    
           
        }
