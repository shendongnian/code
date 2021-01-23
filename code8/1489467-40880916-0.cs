    private void FillDropDownList()
        {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from students", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
       
        DropDownList1.DataTextField = ds.Tables[0].Columns["FullName"].ToString();
        DropDownList1.DataValueField = ds.Tables[0].Columns["id"].ToString();
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataBind();
    }
