    public partial class Default : System.Web.UI.Page
    {
        protected string _SubCodeHeader1 { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _SubCodeHeader1 = DateTime.Now.ToString();
            }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            _SubCodeHeader1 = DateTime.Now.ToString();
        }
    
        protected void Page_PreRender(object sender, EventArgs e)
        {
            DataBind();
        }
    }
