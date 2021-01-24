    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private TelemetryClient TelemetryClient { get; }
        public ExceptionFilter(TelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new
            {
                error = context.Exception.Message
            });
            TelemetryClient.TrackException(context.Exception);
        }
    }
