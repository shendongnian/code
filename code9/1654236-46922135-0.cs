    public sealed class MyGlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IEmailService _emailService;
        public NlogExceptionHandler(
            RequestDelegate next,
            IEmailService emailService)
        {
            _next = next;
            _emailService = emailService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                
                await _next(context);
            }
            catch (Exception ex)
            {
                try
                {
                    _emailService.SendEmail(ex.ToString());
                }
                catch (Exception ex2)
                {
                    //Its good practice to have a second catch block for simple logging in case the email fails too
                }
                throw;
            }
        }
    }
