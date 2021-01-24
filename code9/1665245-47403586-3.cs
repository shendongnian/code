    public interface IEmailService
    {
        EmailResult PasswordRecovery(PasswordRecoveryModel model);
    }
    public class Foo
    {
        private readonly IEmailService emailService;
        public Foo(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public void DoSomething()
        {
            this.emailService.PasswordRecovery(new PasswordRecoveryModel { ... });
        }
    }
