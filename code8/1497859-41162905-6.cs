    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\kenlui\Documents\LoginDate.mdf;Integrated Security=True;Connect Timeout=30;"))
        using (SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Login where Username = @userName and Password = @password", con))
        using (DataTable dt = new DataTable())
        {
            sda.SelectCommand.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar) { Value = textBox1.Text });
            // this should be a hash of the password, not the plain text value
            sda.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = textBox2.Text });
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
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
