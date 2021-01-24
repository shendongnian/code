    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager
        .AppSettings["MyConnectionString"];
        SqlDataSource1.ID = "SqlDataSource1";
        this.Page.Controls.Add(SqlDataSource1);
        SqlDataSource1.SelectCommand = "SELECT * FROM my_table_name";
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
