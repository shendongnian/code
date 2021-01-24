    public class AiExceptionLogger : ExceptionLogger
    {
        public  override async void Log(ExceptionLoggerContext context)
        {
            if (context != null && context.Exception != null)
            {
                ExceptionTelemetry telemetry = new ExceptionTelemetry(context.Exception);
                using (var ms = new MemoryStream())
                {
                    await context.Request.Content.CopyToAsync(ms);
                    var requestBody = Encoding.UTF8.GetString(ms.ToArray());
                    telemetry.Properties.Add("Request Body", requestBody);
                }
                
                Logger.LogException(telemetry);
            }
            base.Log(context);
        }
    }
