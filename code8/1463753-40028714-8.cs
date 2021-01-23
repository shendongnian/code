    public class LeadController : Controller
    {
        public ActionResult Index()
        {    
            return View();
        }
    
        [HttpPost]
        [AllowAnonymous]
        public JsonResult PostOnCRM(UserModel model)
        {
            bool isValidEmail = IsValidEmail(model.Email);
    
            if (!isValidEmail)
                throw new Exception("E-mail is not a valid one");
                
            // ...
    
            return Json(new { success = true, responseText = "Your message successfuly sent!" });
        }
    
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
                return false;
    
            try
            {
                email = new MailAddress(email).Address;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
