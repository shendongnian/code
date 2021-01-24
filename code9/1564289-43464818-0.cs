    String strConnString = ConfigurationManager.ConnectionStrings["CallcenterConnectionString"].ConnectionString;
    DataTable dt = new DataTable();
    using(var con = new SqlConnection(strConnString))
    {
        using(var cmd = new SqlCommand("UserManagement", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CallType", SqlDbType.VarChar).Value = ddlCalltype.SelectedValue.ToString();
	        cmd.Parameters.Add("@Format", SqlDbType.VarChar).Value = ddlFormat.SelectedValue.ToString();
	        cmd.Parameters.Add("@disposition", SqlDbType.VarChar).Value = ddlDisp.SelectedValue.ToString();
	        cmd.Parameters.Add("@SubDisposition", SqlDbType.VarChar).Value = ddlSubdisp.SelectedValue.ToString();
            using(var da = new SqlDataAdapter())
            {
                da.SelectCommand = cmd;
	            da.Fill(dt);
            }
        }
    }
	gvDetails.DataSource = dt;
	gvDetails.DataBind();
	gvDetails.Visible = true;
