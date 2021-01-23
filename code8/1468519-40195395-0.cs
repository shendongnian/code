    // Check if comboBox10.SelectedItem is null, set temp variable
    string comboBox10Text = comboBox10.SelectedItem == null ? String.Empty : comboBox10.Text;
    
    OleDbCommand cmd = new OleDbCommand();
    cmd.CommandType = CommandType.Text;
    // Update query string to use comboBox10Text instead of accessing SelectedItem
    cmd.CommandText = "insert into data ([Auto Date],AKA,[Phone Number],[R ID],[Related Phone],[Profession]) values ('" + textBox1.Text + "','" + textBox12.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox10Text + "')";
    cmd.Connection = con;
    con.Open();
    cmd.ExecuteNonQuery();
    System.Windows.Forms.MessageBox.Show("Data Inserted Successfully");
    con.Close();
