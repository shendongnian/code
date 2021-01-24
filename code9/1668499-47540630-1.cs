    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {  
        GridView1.PageIndex = e.NewPageIndex;  
        BindData();  
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = AdvertSearch(txtTitle.Text,txtDateI.Text,txtDateF.Text);
        GridView1.DataBind();
    }
