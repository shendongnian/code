    using System;
    using System.Web.Script.Serialization;
    
    namespace DemoWebForm
    {
        public partial class Default : System.Web.UI.Page
        {
            [System.Web.Services.WebMethod]
            public static string GetCurrentDate(string value)
            {
                return new JavaScriptSerializer().Serialize(
                    string.Format("{0} - {1}", DateTime.Now, value));
            }
        }
    }
