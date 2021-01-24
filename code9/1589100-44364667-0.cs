        private void button1_Click(object sender, EventArgs e)
        {
            // use this local variable to prevent keeping sql connection and an active data reader longer than neccessary
            var hasRows = false; 
            // You should really get the connection string from your web.config file, I left it hard coded so that you can test.
            var connectionString = @"Data Source=DESKTOP-UHGLPQ8\SQLEXPRESS;Initial Catalog=Test Vol;Integrated Security=True";
            // Use the using statement for any local variable that implements the IDisposable interface
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM MastVolData WHERE [RegiD] = @RegiD;", con))
                {
                    cmd.Parameters.Add("@RegiD", SqlDbType.VarChar).Value = textBox1.Text;
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        hasRows = dr.HasRows;
                    }
                }
            }
            // Now that your sql connection is closed and disposed, you can use ShowDialog
            if (hasRows)
            {
                using (Form2 frm = new Form2(textBox1.Text))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Wrong I.D! Please try again!");
            }
            textBox1.Clear();
        }
    }
