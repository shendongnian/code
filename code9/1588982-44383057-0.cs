      public class AiExceptionLogger : ExceptionLogger
            {
                public override void Log(ExceptionLoggerContext context)
                {
                    if (context != null && context.Exception != null)
                    {//or reuse instance (recommended!). see note above
                        var ai = new TelemetryClient();
                        //Here you need get the CustomerId, JobId, and other. For example get the current user id
                        string re = HttpContext.Current.User.Identity.Name;
    
                        // Set up some properties:
                       //Here you need get what you need and add them to the properties
                        var properties = new Dictionary<string, string> {{ "Users", "vvvvv" } };
                            // Send the exception telemetry:
                        ai.TrackException(context.Exception, properties);
                    }
                    base.Log(context);
                }
            }
