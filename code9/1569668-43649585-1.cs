    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
