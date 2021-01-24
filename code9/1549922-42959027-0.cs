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
    }
