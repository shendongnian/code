    // if you're using ASMX web service, change to this class declaration:
    // public class Crud : System.Web.Services.WebService
    public class Crud : System.Web.UI.Page
    {
    
        [System.Web.Services.WebMethod]
        public static String generateFiles(String name)
        {
            return generateHtml(name);
        }
    
        private String generateHtml(String name)
        {
            var filename = "C:\temp\"" + name + ".html";
        
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                return "True";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
    }
