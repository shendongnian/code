    <%@ WebHandler Language="C#" Class="JsonHandler" %>
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    
    public class JsonHandler : IHttpHandler
    {
    
       class Helper{
            public string label;
            public string value;
            public string desc;
       }
    
        public void ProcessRequest(HttpContext context)
        {
            List<Helper> list = new List<Helper>();
            
            list.Add (new Helper(){
            label="771678 - - Fuel injector for Ford - L.Saldo: 0 - Reserv.: 0 - Order: 0 - KPris : 0,00 kr",
            value="771678",
    desc="Fuel injector for Ford" }       
            );
            context.Response.ContentType = "application/json";
            
            var jsonString = (new System.Web.Script.Serialization.JavaScriptSerializer()).Serialize(list);
    
            context.Response.Write(jsonString);
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
