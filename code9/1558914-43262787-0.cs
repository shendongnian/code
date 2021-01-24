    protected void Page_Load(object sender, EventArgs e)
    {
        if(HttpContext.Current.Session["userId"].Equals(0))
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if(!IsPostBack)
            {
                loadMyAccount((int) HttpContext.Current.Session["userId"]);
            }
        }
    }
