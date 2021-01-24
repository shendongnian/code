    [RoutePrefix("home")]
    public class HomeController : Controller {
        //Matches GET home
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Index() {
            // DEBUGGING - TEST WRITING USER TO DB
            var user = new UserModel(Guid.NewGuid().ToString(), "test", "test", "test@test.com", "tester");
            await user.WriteToDatabase();
            // DEBUG END
    
            return View();
        }
    }
