    public partial class Page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            var letter = HttpContext.Current.Request["m"] != null ?
                         HttpContext.Current.Request["m"] : "A";
            this.MasterPageFile = "~/Master" + letter + ".Master";
        }
    }
