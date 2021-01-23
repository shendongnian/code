    // I've hidden the connection string by ...
    using (var con2 = new SqlConnection(@"...")) {
      // using will close connection for you, do not call Close() direct
      con2.Open();
    
      // Let sql be readable and parametrized
      string sql = 
        @"SELECT * 
            FROM auto 
           WHERE autonr = @prm_autonr";
    
      using (var cmd2 = new SqlCommand(sql, con2)) {
        cmd2.Parameters.AddWithValue("@prm_autonr", autonrTextBox.Text);
     
        using (var reader = cmd2.ExecureReader()) {
          // Do we have any records?
          if (reader.Read()) {
            // To be on the safe side use Convert.ToString():
            // what if the database field is of type Number(8, 5)? NVarChar2(11)?
            autonrTextBox.Text = Convert.ToString(reader[0]);
            kentekenTextBox.Text = Convert.ToString(reader[1]);
            merkTextBox.Text = Convert.ToString(reader[2]);
            modelTextBox.Text = Convert.ToString(reader[3]);
            kleurTextBox.Text = Convert.ToString(reader[4]);
            categorieTextBox.Text = Convert.ToString(reader[5]);
            pkSTextBox.Text = Convert.ToString(reader[6]);
            apkTextBox.Text = Convert.ToString(reader[7]);
            kilometerstandTextBox.Text = Convert.ToString(reader[8]);
            bijtellingTextBox.Text = Convert.ToString(reader[9]);
            energielabelTextBox.Text = Convert.ToString(reader[10]);
          } 
        }
      }
    }
