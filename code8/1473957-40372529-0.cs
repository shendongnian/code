    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=JAVY26;Initial Catalog=Pharmacies;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT Code, Description, Next_Code FROM Liguanea_Lane WHERE code LIKE '%" + search.Text+"%'; ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                    
                while (dr.Read())
                {
                   string scode = dr.GetString(dr.GetOrdinal("next_code"));
                    textBox2.Text = scode;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
