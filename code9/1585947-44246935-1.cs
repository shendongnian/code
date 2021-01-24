    [Authorize(Policy = "EmployeeOnly")]
    public class ClientAreaController : Controller
    {
        public IActionResult Index()
        {
        }
    }
