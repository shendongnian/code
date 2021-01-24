    private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\hp\documents\visual studio 2015\Projects\PersonalFinancialSoftware\PersonalFinancialSoftware\Login.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandText = "SELECT COUNT (*) FROM Table where UserID = @userid AND Password = @password";
            cmd.Parameters.AddWithValue("@userid", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            object result = cmd.ExecuteScalar();
            
            string useridlogin = Convert.ToString(result);
            conn.Close();
    
            if (useridlogin != " ")
            {
                Home_Page homepage = new Home_Page();
                homepage.Show();
            }
            else
            {
                MessageBox.Show("Invalid ID or password, please try again!", "Info", MessageBoxButtons.OK);
            }
        }
