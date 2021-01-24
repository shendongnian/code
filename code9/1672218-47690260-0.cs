    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddl1.DataSource = source;
            ddl1.DataBind();
            ddl2.DataSource = source;
            ddl2.DataBind();
        }
    }
