    public class AccountController: Controller
    {
        public ActionResult Login(Customer obj)
        {
            Session.Clear();
            return View();
        }
    }
