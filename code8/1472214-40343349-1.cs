       private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=JAVY26;Initial Catalog=Pharmacies;Integrated Security=True";
                string query = "SELECT * FROM dbo.Liguanea_Lane WHERE code = '" + comboBox2.Text + "' ; ";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string sdes = dr.GetString(dr.GetOrdinal("description"));
                    textBox5.Text = sdes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
