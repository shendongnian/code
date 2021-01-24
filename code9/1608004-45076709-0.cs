    using Microsoft.ApplicationInsights;
    using System.Net.Http;
    using System.Web.Http.Filters;
    
    namespace BotDemo.App_Start
    {
        public class ExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext ctx)
            {
                HandleError(ctx);
            }
    
            private static void HandleError(HttpActionExecutedContext ctx)
            {
                ctx.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ctx.Exception.Message)
                };
    
                var client = new TelemetryClient();
                client.TrackException(ctx.Exception);
            }
        }
    }
