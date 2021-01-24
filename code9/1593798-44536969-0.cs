    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable dataTable = new DataTable();
        string constr =      ConfigurationManager.ConnectionStrings["gridconnection"].ConnectionString;
        string query = "select * from GridExcel";
        SqlConnection con1 = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(query, con1);
        con1.Open();
        // create data adapter
        SqlDataReader reader = cmd.ExecuteReader();
        // this will query your database and return the result to your datatable
        dataTable.Load(reader);
        Gridview1.DataSource = dataTable;
        Gridview1.DataBind();
        ViewState["CurrentTable"] = dataTable;
        con1.Close();
      }
    }
