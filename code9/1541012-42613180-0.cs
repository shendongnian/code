    // Wrap IDisposable into using
    using (MySqlConnection conString = new MySqlConnection("...")) {
       conString.Open();
       // Make SQL Readable
       string sql = 
         @"INSERT INTO purchaseorder(
             orNo, 
             ProdNo, 
             Quantity, 
             total)
           VALUES(
             @ORNo,
             @ProductNo,
             @quantity,
             @total)";
      // Wrap IDisposable into using
      using (MySqlCommand command1 = new MySqlCommand(sql, conString))  {
        command1.Parameters.AddWithValue("@ORNo", dataGridView1.Rows.Count);
        command1.Parameters.AddWithValue("@ProductNo", dataGridView1.Rows.Count);
        command1.Parameters.AddWithValue("@quantity", dataGridView1.Rows.Count);
        command1.Parameters.AddWithValue("@total", textBox6.Text);
        command1.ExecuteNonQuery();
      }
    }
