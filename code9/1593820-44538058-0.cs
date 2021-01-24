    using (SqlCommand cmd = new SqlCommand(query, con))
    {
         cmd.Parameter.add("@uniId",Session["UniId"].ToString());
         DataSet ds = new DataSet();
         
         using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
         {
              da.Fill(ds);
         }
         if (ds.Tables.Count > 0)
         {
              dt = ds.Tables[0];
         }
    }
