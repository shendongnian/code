        int a;
        using(var conn = new SqlConnection(YOURCINNECTIONSTRING))
        {
            con.Open();
            string query = "Select Max (invno) From Invoicesdata";
            var cmd = new SqlCommand(query, con);
            using(SqlDataReader reader = cmd.ExecuteReader())
             {
                 if (reader.Read())
                 {
           
               
                 }
             }
          }
    }
