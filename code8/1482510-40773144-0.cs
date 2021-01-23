    private void FillCombo()
        {
         
                comboBox4.Items.Clear();
                try
                {
                    string connectionString = "Data Source=LPMSW09000012JD\\SQLEXPRESS;Initial Catalog=Pharmacies;Integrated Security=True";
                    using (SqlConnection con2 = new SqlConnection(connectionString))
                    {
                        con2.Open();
                        string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES ";
                        SqlCommand cmd2 = new SqlCommand(query, con2);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        while (dr2.Read())
                        {
                            int col = dr2.GetOrdinal("TABLE_NAME");
                            comboBox4.Items.Add(dr2[col].ToString());
                        }
                       // comboBox4.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
