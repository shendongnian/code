            using Microsoft.AspNet.Identity;
            using Microsoft.Owin.Security;
            using Newtonsoft.Json.Linq;
            using System;
            using System.Collections.Generic;
            using System.Collections.Specialized;
            using System.Diagnostics;
            using System.IO;
            using System.Linq;
            using System.Net.Http;
            using System.Security.Claims;
            using System.Threading.Tasks;
            using System.Web;
            using System.Web.Http;
            using System.Web.Http.Cors;
            using System.Web.Mvc;
            
            namespace Servicebus.Controllers
            {
                [System.Web.Mvc.AllowAnonymous]
                [EnableCors(origins: "*", headers: "*", methods: "*")]
                public class AuthenticationController : Controller
                {
            
                    /// <summary>
                    /// Service from the business layer to get the right information
                    /// </summary>
                    private IAuthenticationService _aService
                    {
                        get
                        {
                            return GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthenticationService)) as AuthenticationService;
                        }
                    }
                    /// <summary>
                    /// Constructor of the hourregistation controller gets the service from the unity container.
                    /// </summary>
                    public AuthenticationController()
                    {
                       
                    }
    //other functions
        }
        }
