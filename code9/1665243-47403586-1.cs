    public interface IEmailService
    {
        EmailResult PasswordRecovery(PasswordRecoveryModel model);
    }
    public class Foo
    {
        public Foo(IEmailService emailService)
        {
            service.PasswordRecovery(new PasswordRecoveryModel { ... });
        }
    }
