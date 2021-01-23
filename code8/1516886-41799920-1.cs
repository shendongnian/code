        [WebService(Namespace = "http://{redacted.com}/json-http-handlers/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class CustomerHandler : IHttpHandler
        {
            public bool IsReusable
            {
                get { return false; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                string json = string.Empty;
    
                // code to do whatever here...
    
                context.Response.Write(json);
            }
