    using (OleDbConnection conn = new OleDbConnection(ConnString))
    {
      using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
      {
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
        cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
      }
    }
