    [Authorize(Roles = "Admin,Employee")] // admin or employee
    public class XController : Controller 
    {
        [Authorize(Roles = "Admin")] // only admin
        public ActionResult ActionX() { ... }
    
        [AllowAnonymous] // anyone
        public ActionResult ActionX() { ... }
    }
