        using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("sp_Cases_ViewAll", con))
        {
            //if (prioritylev == "")
            //    cmd.Parameters.AddWithValue("@PriorityLevelKey", DBNull.Value);
            //else
            cmd.Parameters.AddWithValue("@PriorityLevelKey", (string.IsNullOrEmpty(prioritylev) ? DBNull.Value : new Guid(prioritylev)));
            cmd.Parameters.AddWithValue("@ProcessStatusKey", (string.IsNullOrEmpty(processkey) ? DBNull.Value : new Guid(processkey)));
            cmd.Parameters.AddWithValue("@SystemUserKey", (string.IsNullOrEmpty(systemuser) ? DBNull.Value : new Guid(systemuser)));
            cmd.Parameters.AddWithValue("@AccountNumber", accnumber);
            cmd.Parameters.AddWithValue("@CustomerName", cusname);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grid_Cases.DataSource = dt;
                grid_Cases.DataBind();
            }
        }
    }
