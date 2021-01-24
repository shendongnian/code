    public class BasePage : System.Web.UI.Page
    {
        public Site master;
        public BasePage()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            master = ((Site)(Page.Master));
        }
    }
