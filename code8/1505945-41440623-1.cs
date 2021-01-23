       protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindData();
        }
    }
     
    private void BindData()
    {
        string query = "SELECT top 10 * FROM Customers";
        SqlCommand cmd = new SqlCommand(query);
        gvCustomers.DataSource = GetData(cmd);
        gvCustomers.DataBind();
    }
     
    private DataTable GetData(SqlCommand cmd)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
