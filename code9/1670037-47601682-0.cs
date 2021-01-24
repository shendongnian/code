    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
       // POST api/login
       [HttpPost]
       public IActionResult Post([FromBody] LoginViewModel login)
       {
          return Ok("Exam Done");
       }
    }
