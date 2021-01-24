    public partial class _Default : System.Web.UI.Page
    {
        string strResponseValue;
        public string ResponseREST 
        { 
            get { return strResponseValue; } 
            set { strResponseValue = value; } 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            strResponseValue = "This is a test";
        }
    }
