    using (var ds = new DataSet())
    {
      using (var con = new SqlConnection("Connection String"))
      {
        using (var cmd = new SqlCommand("SP_AUTH_SEARCH", con))
        {
          using (var adapter = new SqlDataAdapter(cmd))
          {
            con.Open();
            adapter.Fill(ds);
          }
        }
      }
      AuthorizationResult auth = null;
      auth = new AuthorizationResult();
    
      foreach (DataRow dr in ds.Tables[0].Rows)
      {
        auth.AuthNo = dr[0].ToString();
      }
    
      return auth;
    }
