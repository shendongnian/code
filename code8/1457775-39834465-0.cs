    namespace WebApplication1.App_Start
    {
        using System.Reflection;
        using System.Web.Mvc;
    
        using SimpleInjector;
        using SimpleInjector.Extensions;
        using SimpleInjector.Integration.Web;
        using SimpleInjector.Integration.Web.Mvc;
        using Owin;
        using Models;
        using Microsoft.AspNet.Identity;
        using Microsoft.AspNet.Identity.EntityFramework;
        using Microsoft.Owin.Security.DataProtection;
        using Microsoft.AspNet.Identity.Owin;
        using Microsoft.Owin.Security;
        using SimpleInjector.Advanced;
        using Microsoft.Owin;
        using System.Web;
        using System.Collections.Generic;
    
        public static class SimpleInjectorInitializer
        {
        }
