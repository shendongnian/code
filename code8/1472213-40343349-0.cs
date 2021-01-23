    void fillCombo()
        {
               try
               {
                   string connectionString = "Data Source=JAVY26;Initial Catalog=Pharmacies;Integrated Security=True";
                   SqlConnection con = new SqlConnection(connectionString);
                   con.Open();
                   string query = "SELECT * FROM dbo.Liguanea_Lane";
                   SqlCommand cmd = new SqlCommand(query, con);
                   SqlDataReader dr = cmd.ExecuteReader();
                   while (dr.Read())
                   {
                       string scode = dr.GetString(dr.GetOrdinal("code"));
                       comboBox2.Items.Add(scode);
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.ToString());
               }*/
        }
