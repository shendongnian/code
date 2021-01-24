    using Microsoft.Owin;
    using Microsoft.Owin.StaticFiles;
    using Owin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace WebApplication22.App_Start
    {
    	public class Startup
    	{
    		public void Configuration(IAppBuilder app)
    		{
    			var clientHostname = System.Configuration.ConfigurationManager.AppSettings["ClientHostname"];
    
    			var staticFileOptions = new StaticFileOptions()
    			{
    				OnPrepareResponse = staticFileResponseContext =>
    				{
    					staticFileResponseContext.OwinContext.Response.Headers.Add("Cache-Control", new[] { "public", "max-age=0" });
    				}
    			};
    			...
    			}
    	}
    }
