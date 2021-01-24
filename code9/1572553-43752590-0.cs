    using (var con = new SqlConnection(strConnString))
    {
        con.Open();
    
        using (cmd = new SqlCommand("ROMA_UserManagement", con))
        {
            cmd.Parameters.Add("@flag", SqlDbType.VarChar).Value = "1";
            cmd.Parameters.Add("@CallType", SqlDbType.VarChar).Value = ddlCalltype.SelectedValue.ToString();
            cmd.Parameters.Add("@Format", SqlDbType.VarChar).Value ="";
            cmd.Parameters.Add("@disposition", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@SubDisposition", SqlDbType.VarChar).Value ="";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dsFormat);
        }
        con.Close();
    }
    
    if (dsFormat.Tables.Count > 0 && dsFormat.Tables[0].Rows.Count > 0)
    {
        ddlFormat.DataValueField = "DISPFORMAT";
        ddlFormat.DataTextField = "FORMATDETAIL";
        ddlFormat.DataSource = dsFormat.Tables[0];
        ddlFormat.DataBind();
        ddlFormat.Items.Insert(0, "<----Select---->");
    }
    
    using (var con = new SqlConnection(strConnString))
    {
        con.Open();
        
        using (cmd1 = new SqlCommand("ROMA_UserManagement", con))
        {
            cmd1.Parameters.Add("@flag", SqlDbType.VarChar).Value = "0";
            cmd1.Parameters.Add("@CallType", SqlDbType.VarChar).Value = ddlCalltype.SelectedValue.ToString();
            cmd1.Parameters.Add("@Format", SqlDbType.VarChar).Value = ddlFormat.SelectedValue.ToString();
            cmd1.Parameters.Add("@disposition", SqlDbType.VarChar).Value = ddlDisp.SelectedValue.ToString();
            cmd1.Parameters.Add("@SubDisposition", SqlDbType.VarChar).Value = ddlSubdisp.SelectedValue.ToString();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.ExecuteNonQuery();
            da1.SelectCommand = cmd1;
            da1.Fill(ds1);
             
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                 dt = ds1.Tables[0];
                 gvDetails.DataSource = ds1; // are you mean to assign dt here?
                 gvDetails.DataBind();
            }
        }
        con.Close();
    }
