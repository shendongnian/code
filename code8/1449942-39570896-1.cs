    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("data source=.; database=Richard2016DB; integrated security=SSPI");
        SqlCommand cmd = new SqlCommand("Select * from dbo.tblEmployee", con);
        con.Open();
        DataTable table = New DataTable();
        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
            da.Fill(table);
        GridView1.DataSource = table;
        GridView1.DataBind();
        con.Close();
    }
