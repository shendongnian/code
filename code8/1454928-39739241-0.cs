    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Web.Script.Services;
    using System.Web.Services;
    
    namespace StackOverflow_Solve.Services
    {
        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {
    
            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string GetMessage()   // Home.CS 
            {
                //return "GOGO";
                Context.Response.Output.Write("Hello World");
                Context.Response.End();
                return string.Empty;
            } 
        }
    }
