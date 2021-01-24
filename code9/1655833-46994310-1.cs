    using System;
    using System.Web;
    public class HandleAllRequestsHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Console.WriteLine("Test!");
        }
        public bool IsReusable => false;
    }
