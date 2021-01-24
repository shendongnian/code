    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly DateTime currentDate = new DateTime(2017, 10, 10);
        private string currentYear = DateTime.Today.Year.ToString();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtArrivalDate.Text = currentDate.ToString();
        }
    }
