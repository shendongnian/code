    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Mobile,Name,State FROM tblEmployee where EmpId= @empId"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@empId", ddlEmployee.SelectedValue);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        lblName.Text = reader["Name"].ToString();
                        lblEmail.Text = reader["Mobile"].ToString();
                        lblState.Text = reader["State"].ToString();
                    }
                    con.Close();
                }
            }
        }
        catch (Exception s)
        {
            HttpContext.Current.Response.Write("Error Occured " + s.Message);
        }
    }
