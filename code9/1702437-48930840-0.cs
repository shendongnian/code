    public class CaptureResponseModule : IHttpModule
        {
            public void Init(HttpApplication application)
            {
                application.EndRequest += (o, s) =>
                {
                    var response = HttpContext.Current.Response;
                    /*capture response for logging/tracing etc. */
                };
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
