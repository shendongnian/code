    protected void CompanyDropDown_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("[dropdownCompany]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            CompanyDropDown.DataSource = cmd.ExecuteReader();
            CompanyDropDown.DataBind();
        }
    }
