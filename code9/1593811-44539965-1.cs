    public class YourController : Controller
    {
            private readonly IUserService _user;
    
            public YourController(IUserService user)
            {
                  _user = user;           
            }
           
            public ActionResult YourMethod()
            {
                var model = _user.GetResult();
                return View(model);
            }
    }
