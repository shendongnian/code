    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCity(Request.QueryString["city"].ToString());
        }
    
    }
    
    protected void LoadCity(string _city)
    {
        try
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "SqlDataSource1";
            this.Page.Controls.Add(SqlDataSource1);
            SqlDataSource1.ConnectionString = "my connection";
            SqlDataSource1.SelectCommand = "select citylocation from citylocationtbl where cityname=@cityname";
            SqlDataSource1.SelectParameters.Add("@cityname", _city);
            RadAutoCompleteBox2.DataSourceID = "SqlDataSource1";
            RadAutoCompleteBox2.DataTextField = "citylocation";
            RadAutoCompleteBox2.DataBind();
        }
        catch (Exception ex)
        {
    
        }
    
    }
