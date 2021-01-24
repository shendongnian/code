    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IEmailService emailService;
        public GlobalExceptionFilter(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public void OnException(ExceptionContext context)
        {
           //do something with this.emailService
        }
    }
