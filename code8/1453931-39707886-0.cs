    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        { /* Set a breakpoint here and make sure: 
               A.) You are hitting this method 
               B.) Get value of e.CommandName */
            if (e.CommandName == "edit")
            {
                // Run your edit/update logic here if needed
            }
            if (e.CommandName == "delete")
            {
                // Delete the record here
                string UserId = GridView1.DataKeys[e.RowIndex].Value.ToString();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                SqlCommand dCmd = new SqlCommand();
                {
                    conn.Open();
                    dCmd.CommandText = "Reviewer_Delete";
                    dCmd.CommandType = CommandType.StoredProcedure;
                    dCmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
                    dCmd.Connection = conn;
                    dCmd.ExecuteNonQuery();
                    // Refresh the data
                    BindDropDownList1();
                    dCmd.Dispose();
                    conn.Close();
                    conn.Dispose();
            }
        }
