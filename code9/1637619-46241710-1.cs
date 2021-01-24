    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult ShowData(FormCollection data)
        {  
             string username=data.GetValues("username")[0];
             string password=data.GetValues("password")[0];       
               string email=data.GetValues("email")[0];
            return Content(username + password + email);
        }
    }
