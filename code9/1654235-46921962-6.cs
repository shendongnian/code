    using Microsoft.Extensions.DependencyInjection;
    public void OnException(ExceptionContext context)
    {
        var emailService = context.HttpContext.RequestServices.GetService<IEmailService>();
        // use emailService
    } 
