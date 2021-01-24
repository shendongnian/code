    public class Crud
    {
        [WebMethod]
        public static String generateFiles(String name)
        {
    
            return(generateHtml(name));
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
