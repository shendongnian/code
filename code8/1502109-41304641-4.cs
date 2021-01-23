    // Controller that depends on the IVerificationSender abstraction
    public class HomeController : Controller
    {
        private readonly IVerificationSender verificationSender;
        public HomeController(IVerificationSender verificationSender, ...) {
            this.verificationSender = verificationSender;
        }
        public void SomeAction() {
            this.verificationSender.SendVerification(user);  
        }
    }
