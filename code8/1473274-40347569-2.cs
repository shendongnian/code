    public class HomeController : Controller {
    
        readonly IEmailService emailService;
    
        public HomeController(IEmailService emailService) {
            this.emailService = emailService;
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailModel email) {
            if(ModelState.IsValid) {
                emailService.Send(email);
                ViewBag.Send = true;
                ModelState.Clear();
            }
            return View(email);
        }
    }
