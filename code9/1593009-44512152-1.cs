    public partial class master : System.Web.UI.MasterPage
    {
        public string _metaA;
        public string _metaB;
        protected void Page_Load(object sender, EventArgs e)
        {
            // ex:
            _metaA = "<meta name=\"description\" content=\"Content\" />";
            _metaB = "<meta name=\"keywords\" content=\"Content\" />";
            Page.Header.DataBind();
        }
    }
