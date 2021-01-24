    [Authorize(Roles = "Administrator")]
    public class AdministrationAreaController : Controller
    {
        public IActionResult Index()
        {
        }
    }
