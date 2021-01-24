    [Route("api/MyLogin")]
    public class LoginController : Controller
        {
            public IActionResult Callback()
            {
                return View();
            }
        }
