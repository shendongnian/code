    public class MainController : Controller {
        private IUsersService usersService;
        public MainController(IUsersService service) {
            this.usersService = service;
        }
        public JsonResult GetAllUsers() {
            var response = usersService.GetAllUsers();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
