    public List<CodeDesc> getCodeTypes()
    {
        try
        {
            List<CodeDesc> L = new List<CodeDesc>(); 
            string query = "select id, descr from code_desc where code_type_id = 0";
            using(OracleConnection con = new OracleConnection(connString))
            using(OracleCommand cmd = new OracleCommand(query, con))
            {
                con.Open();
                // Execute command, create OracleDataReader object
                using(OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       CodeDesc c = new CodeDesc();
                       c.id = reader.GetInt32(0);
                       c.description = reader.GetString(1);
                       L.Add(c);
                    }
                }
           }
           System.Diagnostics.Debug.WriteLine(L);
           return L;
      }
