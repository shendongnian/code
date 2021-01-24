    public partial class Default : System.Web.UI.Page
    {
       [System.Web.Services.WebMethod]
       public static string Delete(string id)
       {
          // Do something
          return new JavaScriptSerializer().Serialize(id + " is successfully deleted");
       }
    }
