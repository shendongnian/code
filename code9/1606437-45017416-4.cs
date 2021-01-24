    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
        gvCustomers.DataSource = GetData("select top 10 * from Customers");
        gvCustomers.DataBind();
    }
    }
 
    private static DataTable GetData(string query)
    {
    string strConnString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = query;
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        string customerId = gvCustomers.DataKeys[e.Row.RowIndex].Value.ToString();
        GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
        gvOrders.DataSource = GetData(string.Format("select top 3 * from Orders where CustomerId='{0}'", customerId));
        gvOrders.DataBind();
    }
    }
