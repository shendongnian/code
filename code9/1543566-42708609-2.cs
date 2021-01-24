     DataTable dt = new DataTable();
     using (SqlConnection con = new SqlConnection(connectionString))
     {
         con.Open();
          using (SqlCommand cmd = con.CreateCommand())
          {
           cmd.CommandText = "Your Stored Procedure Here";
           cmd.CommandType = StoredProcedure;
           using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(dt);
                 return dt;
            }
          }
      }
