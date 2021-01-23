    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace WebApplication2
    {
        /// <summary>
        /// Summary description for PhysicalPathHandler
        /// </summary>
        public class PhysicalPathHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(HttpContext.Current.Server.MapPath("docPath"));
            }
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
