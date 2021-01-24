     namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private static int n = 0;
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                ++n;
                Button1.Text = n.ToString();
            }
        }
    }
