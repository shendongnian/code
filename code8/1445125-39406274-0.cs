    if (ddlProject.SelectedValue != "0")
    {
       UpdateDatabase();      
    }
    
    private void UpdateDatabase()
    {
           string queryInsert;
            DataTable dtval = new DataTable();
            dtval = CF.ExecuteDT("Select BOOKING_NO from xxacl_pN_LEASES_ALL where project_id = '" + ddlProject.SelectedValue + "' and building_id = '" + ddlBuilding.SelectedValue + "'");
    
            for (int i = 0; i < dtval.Rows.Count; i++)
            {
                string StrSeq = CF.ExecuteScaler("Select xxcus.xxacl_pN_LEASES_ALL_SEQ.next_val from xxacl_pN_LEASES_ALL");
                queryInsert = "Insert into xxacl_pN_LEASES_ALL_h select '" + StrSeq + "', SYSDATE FROM xxacl_pn_leases_all where booking_no = '" + dtval.Rows[i]["BOOKING_NO"].ToString() + "'";
                OracleConnection conUpdate = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OracleConn"].ToString());
                OracleCommand cmd1 = new OracleCommand();
                string allQueryUpdate = queryInsert;
                cmd1.CommandText = allQueryUpdate;
                cmd1.Connection = conUpdate;
                conUpdate.Open();
                cmd1.ExecuteNonQuery();
            }
    
            string queryUpdate;
            queryUpdate = "update xxacl_pN_LEASES_ALL set ASSIGNED_TO = '" + ddlSalesUser.SelectedValue + "'";
    
            OracleConnection conUpdate1 = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OracleConn"].ToString());
            OracleCommand cmd2 = new OracleCommand();
            string allQueryUpdate1 = queryUpdate;
            cmd2.CommandText = allQueryUpdate1;
            cmd2.Connection = conUpdate1;
            conUpdate1.Open();
            cmd2.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record updated successfully');window.location ='FrmHoldingCoordinateUpdate.aspx?Redirect=" + Request.QueryString["Redirect"] + "&userid=" + Request.QueryString["userid"].ToString() + "';", true);        
    }
