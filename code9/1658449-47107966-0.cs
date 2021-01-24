    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GridData"] != null)
                {
                    DataTable dt = new DataTable();
                    dt = Session["GridData"] as DataTable;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
