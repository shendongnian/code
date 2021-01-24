    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //normally you would bind here
        }
        //but now bind grid every page load
        GridView1.DataSource = Common.LoadFromDB();
        GridView1.DataBind();
    }
