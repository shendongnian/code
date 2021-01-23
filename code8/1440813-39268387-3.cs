     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            linkid.Visible = false;
        }
    }
    protected void btnAnalyse_Click(object sender, ImageClickEventArgs e)
    {
        if (linkid.Visible == false)
        {
            linkid.Visible = true;
        }
    }
     protected void btnAnother_Click(object sender, EventArgs e)
        {
         linkid.Visible = false;
        }
