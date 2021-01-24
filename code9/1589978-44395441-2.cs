    SqlCommand cmd = new SqlCommand..the query for getting unique state
    con.Open();
    using ( SqlDataReader rdr = cmd.ExecuteReader())
      {
        while (rdr.Read())
          {
              this.STATE.Text = rdr["State"].ToString();
           }
        }
