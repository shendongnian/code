    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = mySource;
            GridView1.DataBind();
        }
        DropDownList ddl = GridView1.HeaderRow.FindControl("DropDownList1") as DropDownList;
        ddl.AutoPostBack = true;
        ddl.SelectedIndexChanged += new EventHandler(ddl_OnSelectedIndexChanged);
    }
