    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    
        if (!IsPostBack)
        {
            Grid_Reload(3);
    
        }
        
        Grid_Reload(1);
        Grid_Reload(2);
    }
