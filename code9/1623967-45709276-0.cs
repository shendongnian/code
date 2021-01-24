    public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    testing.Text = "en";
                    testing1.Text = "ja";
                }
                
            }
    
            protected void Switch(object sender, EventArgs e)
            {
                string tempLanguage = testing1.Text;
    
                testing1.Text = testing.Text;
                testing.Text = tempLanguage;
    
            }
        }
