    class OopsExceptionHandler : ExceptionHandler
    {
        public override void HandleCore(ExceptionHandlerContext context)
        {
            context.Result = new TextPlainErrorResult//you have to create this class
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong." +
                          "Please contact support@contoso.com so we can try to fix it."
            };
        }
    }
