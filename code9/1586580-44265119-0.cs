    using (var conn = new SqlConnection("your connection"))
    {
      using (var cmd = new SqlCommand(sql, conn))
      {
        conn.Open();
        using (var rdr = cmd.ExecuteReader())
        {
          ...
        }
      }
    }
