    void fillCari()//fill dropdown with values
        {
            try
            {
                string connectionString = "Data Source=CMDLAP126;Initial Catalog=Carimed_Inventory;User ID = sa; Password = 123456;";
                SqlConnection con2 = new SqlConnection(connectionString);
                con2.Open();
                string query = "SELECT DISTINCT Item_Description FROM dbo.Carimed"; //select Convert(nvarchar(50),Item_Description)+ ':' +Convert(nvarchar(50),Item#) as Combined from Carimed
                SqlCommand cmd2 = new SqlCommand(query, con2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    string cari_des = dr2.GetString(dr2.GetOrdinal("Item_Description"));
                    suggestComboBox1.Items.Add(cari_des);
                    suggestComboBox1.Text.Trim();
                }
                //con2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
