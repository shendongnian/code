     string sqlpquery = "SELECT * FROM FeedPreping WHERE path = @path AND subdirectory = @subd";
    // Added these so you can do a NULL check and default if necessary
    var qryPath = dt.Rows[0]["path"];
    var qrySubd = dt.Rows[0]["subd"];
     using (SqlConnection conn = new SqlConnection(connectionString)) {
          conn.Open();
          using (SqlCommand cmd = new SqlCommand(sqlpquery, conn)) {
               cmd.Parameters.AddWithValue("@path", qryPath);
               cmd.Parameters.AddWithValue("@subd", qrySubd);
               try {
                    // sql execution and read here
               }
               catch {
                    // exception handling
               }
          }
               conn.Close();
      }
