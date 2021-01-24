     string sqlpquery = "SELECT * FROM FeedPreping WHERE path = @path AND subdirectory = @subd";
     using (SqlConnection conn = new SqlConnection(connectionString)) {
          SqlCommand cmd = new SqlCommand(sqlpquery, conn);
          cmd.Parameters.AddWithValue("@path", dt.Rows[0]["path"]);
          cmd.Parameters.AddWithValue("@subd", dt.Rows[0]["subd"]);
          conn.Open();
          // sql execution and read here
          conn.Close();
     }
