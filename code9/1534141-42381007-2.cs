    public class HomeController : Controller
    {
        private EmailService emailService;
        public HomeController()
        {
             this.emailService = new EmailService();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitInput()
        {
            string  fromEmail = Email,
                    fromName =  Name,
                    toEmail =   "user@domain.com",
                    subject =   "ASP.NET Core with MailKit"
                    content =   Message
                    site =      Website,
                    company =   CompanyName;
            var emailSentStatus = this.emailService.SendEmail(fromMail, fromName, toEmail, subject, content);
           
            if(emailSentStatus == "success")
            {
                 //Logic of email sent successfully.
            }
            else
            {
                 //Logic of email not sent successfully.
            }
            return View();
        }
    }
