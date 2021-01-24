    protected void Page_Load(object sender, EventArgs e)
    {
        if(!isPostBack)
        {
              if(Request.QueryString["id"] != null)
              {
                      ViewState["id"]=Request.QueryString["id"];
              }
        }
    }
