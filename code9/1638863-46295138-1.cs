    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
    
            dt.Rows.Add("u001", "jack");
            dt.Rows.Add("u002", "fred");
    
            my_testgrid.DataSource = dt;
            my_testgrid.DataBind();
        }
    }
  
