    namespace MyNamespace
    {
        public class ApplePayMerchantIdDomainAssociation : IHttpHandler
        {
            public bool IsReusable => true;
    
            public void ProcessRequest(HttpContext context)
            {
                var wrapper = new HttpContextWrapper(context);
                ProcessRequest(wrapper);
            }
    
            public void ProcessRequest(HttpContextBase context)
            {
                var type = GetType();
                var assembly = type.Assembly;
    
                string resourceName = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}.apple-developer-merchantid-domain-association",
                    type.Namespace);
    
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        context.Response.StatusCode = 404;
                    }
                    else
                    {
                        stream.CopyTo(context.Response.OutputStream);
    
                        context.Response.ContentType = "text/plain";
                        context.Response.StatusCode = 200;
                    }
                }
            }
        }
    }
