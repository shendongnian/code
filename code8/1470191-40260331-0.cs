    using System.Web;
    namespace WebApplication1.App_Start
    {
    using System;
    public class RequestHandler : HttpApplication,IHttpModule
    {
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        public void Init(HttpApplication context)
        {
            
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_RequestCompleted;
        }
        void context_RequestCompleted(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;
            var response = context.Response;
            context.Response.Write(response.Charset);
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;
            var url = context.Request.Url;
            context.Response.Write(url.AbsoluteUri);
        }
        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    }
