    // Extract methods, don't cram everything in OnClick
    private void FeedFriendsListBox() {
      string oracleDb = @"connection string";
      //DONE: wrap IDisposable into using
      using (OracleConnection conn = new OracleConnection(oracleDb)) {
        conn.Open();
        //DONE: Make Sql readable - format it out and use names for the parameter(s)
        string sql =
          @"SELECT NAME, 
                   ADDRESS  
              FROM FRIENDS 
             WHERE AGE = :prm _Age";
        //DONE: wrap IDisposable into using
        using (OracleCommand cmd = new OracleCommand(sql, conn)) {
          cmd.Parameters.Add(new OracleParameter(txtlist.Text, OracleDbType.Decimal));
          //DONE: wrap IDisposable into using 
          using (var reader = cmd.ExecuteReader()) {
            if (!reader.HasRows) {
              listBox1.Text = "Not Found";
              MessageBox.Show("Data Not found", "NOT FOUND", 
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
              return;
            }
            //DONE: Value is zero based
            //DONE: use formatting (string interpolation), not concatenating
            while (reader.Read())
              listBox1.Items.Add($"{reader.GetValue(0)} from {reader.GetValue(1)}");
          }
        }
      }
    }
