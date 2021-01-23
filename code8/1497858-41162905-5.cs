    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\kenlui\Documents\LoginDate.mdf;Integrated Security=True;Connect Timeout=30;"))
        using (SqlCommand sda = new SqlCommand("Select 1 from Login where Username = @userName and Password = @password", con))
        {
            sda.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar) { Value = textBox1.Text });
            // this should be a hash of the password, not the plain text value
            sda.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = textBox2.Text });
            var result = sda.ExecuteScalar();
            if (result != null && 1 == (int)result)
            {
                this.Hide();
                main ss = new main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please Check Username and Password");
            }
        }
    }
