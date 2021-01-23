    public partial class WebForm : Page, IPostBackEventHandler
    {
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    
                }
            }
    
            public void RaisePostBackEvent(string eventArgument)
            {
                 // do somethings at here
            }
    }
