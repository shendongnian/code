     DataTable dt = new DataTable();
     using (SqlConnection con = new SqlConnection(connectionString))
     {
         con.Open();
          using (SqlCommand cmd = con.CreateCommand())
          {
           //sample stored procedure with parameter:
           // "exec yourstoredProcedureName '" + param1+ "','" + param2+ "'";
           cmd.CommandText = "Your Stored Procedure Here";
           cmd.CommandType =CommandType.StoredProcedure;
           using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(dt);
                 return dt;
            }
          }
      }
