    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["ReqID"] != null)
                ddlRequestNo.SelectedValue = Request.QueryString["ReqID"].ToString();
        }
    }
