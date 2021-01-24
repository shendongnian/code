    using(SqlConnection sqlConn = new SqlConnection("Your database Connection String")) {
     using(SqlCommand cmd = new SqlCommand()) {
      cmd.CommandText = "dbo.ArchiveData";
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Connection = sqlConn;
      sqlConn.Open();
      cmd.ExecuteNonQuery();
     }
    }
