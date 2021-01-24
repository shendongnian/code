    private static int PageSize = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDummyRow();
        }
    }
    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("CustomerID");
        dummy.Columns.Add("ContactName");
        dummy.Columns.Add("City");
        dummy.Rows.Add();
        gvCustomers.DataSource = dummy;
        gvCustomers.DataBind();
    }
    [WebMethod]
    public static string GetCustomers(string searchTerm, int pageIndex)
    {
        string query = "[GetCustomers_Pager]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();
    }
    private static DataSet GetData(SqlCommand cmd, int pageIndex)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "Customers");
                    DataTable dt = new DataTable("Pager");
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = PageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    ds.Tables.Add(dt);
                    return ds;
                }
            }
        }
    }
