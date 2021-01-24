    public partial class WebForm1 : System.Web.UI.Page
    {
        public static readonly DateTime DefaultDate = new DateTime(2017, 10, 10);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtArrivalDate.Text = DefaultDate.ToString();
        }
        
    }
