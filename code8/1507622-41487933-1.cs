    public class StaticObjects
    {
        public static string UserRole  
        { 
            get
            {
                try
                {
                    return (string)HttpContext.Current.Session["UserRole"];
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserRole"]=value;
            }
        }
        public static bool AuthorizeExecution(EventHandler method)
        {
            bool autorized = YourDataBaseQuery(UserRole, method.Method.Name);
            return autorized;
        }
     }
        ////////////////////////////// ANOTHER FILE ///////////////// 
        public static void DownloadFile_ServerClick(object sender, EventArgs e)
        {
            //You send the method itself because it fits the delegate "EventHandler"
            if(!StaticObjects.AuthorizeExecution(DownloadFile_ServerClick))
                return;
        }
