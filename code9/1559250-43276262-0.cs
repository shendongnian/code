    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public GridView myGridView
        {
            get
            {
                return GridView1;
            }
            set
            {
                GridView1 = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
