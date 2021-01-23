    using System.Web.Services;
    
    namespace DemoWebForm
    {
        public partial class DetailView : System.Web.UI.Page
        {
            [WebMethod(EnableSession = true)]
            public static string Test(string pid)
            {
                return "Hello " + pid;
            }
        }
    }
