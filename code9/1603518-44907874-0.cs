    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public string MasterBodyMessage // you can use some meaningfull name over here.
        {
            get { return this.lblMasterbodyMessage.Text; }
            set { this.lblMasterbodyMessage.Text = value; }
        }  
    }
 
