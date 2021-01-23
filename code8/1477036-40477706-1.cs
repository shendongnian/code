     using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"]))
     {
         string sql = "INSERT INTO testing (name) VALUES (@name)";
         SqlCommand cmd = new SqlCommand(sql, conn);
         cmd.Parameter.Add(New SqlParameter("@name", txtBox.Text));
         int rowsAffected = cmd.ExecuteNonQuery();
         conn.Close();
     }
