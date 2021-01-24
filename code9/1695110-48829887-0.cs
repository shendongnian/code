    public class ErrorHandlerAttribute : FunctionExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            string body = $"ErrorHandler called. Function '{exceptionContext.FunctionName}': {exceptionContext.FunctionInstanceId} failed. ";
            CombineErrorWithAllInnerExceptions(exceptionContext.Exception, ref body);
            string[] emailList = System.Configuration.ConfigurationManager.AppSettings["SendErrorEmails"].Split(';');
            await SendEmail.SendErrorNotificationAsync("WebJob - Common Driver Error", body);
        }
        private void CombineErrorWithAllInnerExceptions(Exception ex, ref string error)
        {
            error += $"ExceptionMessage: '{ex.Message}'.";
            if (ex is Domain.BadStatusCodeException)
            {
                error += $"Status code: {((Domain.BadStatusCodeException)ex).StatusCode}";
            }
            if (ex.InnerException != null)
            {
                error += $"InnerEx: ";
                CombineErrorWithAllInnerExceptions(ex.InnerException, ref error);
            }
        }
    }
