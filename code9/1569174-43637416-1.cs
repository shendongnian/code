    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = mijnDatabaseBron;
            GridView1.DataBind();
        }
    }
