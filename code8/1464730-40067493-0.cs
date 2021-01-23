    public class BasePage:System.Web.UI.Page
    {
       public int returnUserType()
       {
         try
         {
           return userType;
         }
         catch
         {
           Response.Write("UserType failed to be returned.");
           return 9;
         } 
      }
    }
    
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int userType = returnUserType();
        }
    }
