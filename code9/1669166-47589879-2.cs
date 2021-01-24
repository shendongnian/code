    [Authorize(Policy = "Administrator")]
    Public class AdminController : Controller
    {
        public IActionResult GetData()
        {
        }
        [Authorize(Policy = "AdminManager")]
        public IActionResult AdministratorOnly()
        {
        }
    }
