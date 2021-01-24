    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            X509Certificate2 cert = new X509Certificate2(httpContext.Request.ClientCertificate.Certificate);
            if (cert == null)
            {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
