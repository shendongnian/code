    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //bind the datasource for the parent gridview
            dgInstitute.DataSource = mySource1;
            dgInstitute.DataBind();
            //find the nested gridview in row 4 and cast it
            GridView nestedGridView = dgInstitute.Rows[3].FindControl("dgProgram") as GridView;
            //bind the datasource for the nested gridview
            nestedGridView.DataSource = mySource2;
            nestedGridView.DataBind();
        }
    }
