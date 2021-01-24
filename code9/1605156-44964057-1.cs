    namespace XXXX.Controllers
    { 
       public class TestController : Controller
       {
            public ActionResult User()
            {
               String UserId = User.Identity.GetUserId().ToString(); 
               ApplicationDbContext db = new ApplicationDbContext();
                var rs = db.Users.Find(UserId);
                var model = new UserViewModel
                { 
                    UserName = rs.UserName,
                    FirstName = rs.FirstName,
                    LastName = rs.LastName,
                    Email = rs.Email
                 };
                 db.Dispose();
                 return View(model);
            }
       }
    }
