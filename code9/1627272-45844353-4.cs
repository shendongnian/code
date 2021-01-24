    public class UserService : IUserService {
        private readonly IEncryption _Encryption;
    
        public UserService(IEncryption Encryption) {
            _Encryption = Encryption;
        }
        //Rest of the service here
    }
    public class UserController : Controller {
        private readonly IUserService _UserService;
        public AccountController(IUserService UserService) {
            _UserService = UserService;
        }
    
        public JsonResult GetLoginLogs(int Id) {
            var Logs = _UserService.GetLoginLogById(Id);
            return Json(Logs, JsonRequestBehavior.AllowGet);
        }
        //The rest of the controller
    }
