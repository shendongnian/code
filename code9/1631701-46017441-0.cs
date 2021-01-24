    [Authorize] //ensure a user is signed-in
    public class MyController : Controller
    {
        [Authorize(Roles = "Administrative,Manager")] // ensure the user is signed in and belongs in one of the roles
        public ActionResult DoSomething()
        {
            return View();
        }
    }
