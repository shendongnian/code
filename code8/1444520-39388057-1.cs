    protected void CmdUpdate_Click(object sender, EventArgs e)
    {
        string query = "select mkey from xxacl_pN_LEASES_ALL where project_id = '" + ddlProject.SelectedValue + "' and "+
                    "building_id = '" + ddlBuilding.SelectedValue + "' and SALES_USER_ID = '" + ddlSalesUser.SelectedValue + "'";
        SqlConnection con = new SqlConnection(ConStr);
        con.Open();
        SqlCommnad cmd = new SqlCommand(query, con);
        int mkey = Convert.ToInt32(cmd.ExecuteScalar());
        if (mkey > 0) //if mkey is numeric
        {
            //Update execution
            query = "Update xxacl_pn_leases_all set ASSIGNED_TO = '' where mkey = mkey";
            SqlCommnad cmd1 = new SqlCommand(query, con);
            cmd1.ExecuteNonQuery();
        }
        cmd.Dispose();
        cmd1.Dispose();
        con.Close();
    }
