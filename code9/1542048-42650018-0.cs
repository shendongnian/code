    using (IDataReader r = query.ExecuteReader())
    {
      while (r.Read())
      {
         // etc.
      }
    }
