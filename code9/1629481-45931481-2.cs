    public class SessionManager
    {        
       
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                }
                else return -1;
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                {
                    return Convert.ToString(HttpContext.Current.Session["UserName"]);
                }
                else return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
     
       //reset user detail and add your custom property 
         public static void SignOutUser()
        {
                      
            UserId = -1;
            UserName = string.Empty;          
           
        }
       
    }
