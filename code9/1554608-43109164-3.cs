    public partial class _default : System.Web.UI.Page
    {
        public string rfcStatus;
        protected void Page_Load (object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rfcStatus = "1";
            }
        }
    }
