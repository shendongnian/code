    using System.Data.SqlClient;
    using System.Data;
    public string strConnection = "Data Source=.; uid=sa; pwd=sa;database=test;";
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        protected void BindData()
        {
            
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserDetails", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
