    public class UsersController : Controller
    {
        private readonly IRequests _requests;
    
        public UsersController(IRequests requests)
        {
            _requests = requests;
        }
    
        public JsonResult GetAllUsers()
        {
            List<User> users = null;
            try
            {
                users = new List<User>();
                var allUsersJsonResults = _requests.GetFromUri(Settings.AllUsersUri);
                users = JsonConvert.DeserializeObject<List<User>>(allUsersJsonResults);
    
                return Json(new UserResponse { usersDetails = users, errorMessage = "" },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(users, JsonRequestBehavior.AllowGet);
            }
        }
    }
