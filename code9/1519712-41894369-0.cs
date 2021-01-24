    public class UserController : Controller {
        readonly IUserService userService;
    
        public UserController(IUSerService userService) {
            this.userService = userService;
        }
    
        [HttpPatch]
        [AllowAdminOnly]
        public JsonResult EditUser(User _user) {
            try {
                if (ModelState.IsValid) {
                    userService.Edit(user);
                    //..should return some result here
                } else {
                    string error_messages = "";
                    foreach (var e in ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList()) {
                        error_messages += e[0].ErrorMessage + "\n";
                    }
                    throw new Exception(error_messages);
                }
            } catch (Exception err) {
                return ErrorHelper(@Resources.Global.error, @Resources.Users.error_editing_user, err.Message);
            }
        }
    }
