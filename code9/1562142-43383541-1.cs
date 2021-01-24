    protected void Page_Load(object sender, EventArgs e)
    {
        //check whether page is postback or not
        //if page is not postback at that time we bind the gridview
        if (!Page.IsPostBack)
        {
          //call the function BindGridView
            BindGridView();
        }
    }
    public void BindGridView()
    {
        //here write connection string
        string strsql = DBConnection.sqlstr;
        //create object for sqlconnection
        SqlConnection sqlcon = new SqlConnection(strsql);
        //here i use the query
        //create the object of sqlcommand
        SqlCommand sqlcmd = new SqlCommand("select * from [User]", sqlcon);
        //create sqldataadapter object and give the sqlcommand as parameter
        SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
        //declare the dataset
        DataSet ds = new DataSet();
        //fill dataset using fill method of SqlDataAdapter
        adp.Fill(ds);
        //bind the GridView1
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
