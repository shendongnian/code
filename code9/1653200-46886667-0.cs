       **Maybe you asking for this only**
         SqlConnection con = new SqlConnection(ConfigurationManager.
         ConnectionStrings["con"].ConnectionString);
         da = new SqlDataAdapter("Select * from User", con);
         dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["Name"] = dt.Rows[0]["Username"].ToString();
            Session["Email"] = dt.Rows[0]["UserEmail"].ToString();
        }  
     //Name like ["Username"].. is of your database column name..//
