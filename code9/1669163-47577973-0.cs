    [Authorize(Roles = "Administrator, Manager")]
    Public class AdminController : Controller
    {
        public IActionResult GetData()
        {
        }
    
        [Authorize(Roles = "Administrator")]
        public IActionResult AdministratorOnly()
        {
        }
    }
