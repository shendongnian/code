    using (OracleDataReader reader = cmd.ExecuteReader())
    {
       while (reader.Read())
          {
             if (!reader.IsDBNull(reader.GetOrdinal("FILE")))
                   {
                     OracleBlob doc = reader.GetOracleBlob(reader.GetOrdinal("FILE"));
                      if (!doc.IsNull)
                       {
                           docBytes = new byte[doc.Length];
                           doc.Read(docBytes, 0, (int)doc.Length);
                       }
                   } 
          }
    }
