    using System;
    using System.Web;
    using System.Threading;
    //using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FilterModule
    {
        class AspxFilter : IHttpModule
        {
            public void Init(HttpApplication app)
            {
                app.BeginRequest += new EventHandler(AspxRedirect);
            }
    
    
    
            private void AspxRedirect(Object s, EventArgs e)
            {
                HttpApplication app = s as HttpApplication;
                HttpRequest req = app.Request;
                HttpContext context = app.Context;
    
                string filePath = context.Request.FilePath;
                string fileExtension = VirtualPathUtility.GetExtension(filePath);
                string fileName = VirtualPathUtility.GetFileName(filePath);
    
                if (fileExtension.ToLower() == ".aspx")
                {
    
                   if (req.QueryString["Redirect"] != null)
                   {
                    String RedirectPath = "Redirect.html";
                    // Build your redirect Path as needed based on the rquest String
                    context.Response.Redirect(RedirectPath);
                    }
                    else
                    {
                    }
                     
                }
    
            }
    
            public void Dispose()
            {
    
            }
    
        }
    }
