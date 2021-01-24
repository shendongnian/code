    public partial class Mainsite_Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            string str = "Lorem ipsum";
            Session["TestVariable"] = str;
        }
    }
