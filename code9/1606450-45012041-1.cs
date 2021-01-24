    public class ManageController : Controller
    {
        public ActionResult Index(string id, string msg)
        {
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            var user = UserManager.FindById(id);
            return View(user);
        }
    }
