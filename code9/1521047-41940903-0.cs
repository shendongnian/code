    void fill()//fill combobox with values
    {
        try
        {
            string connectionString = "Data Source=cmcentraldb;Initial Catalog=CMLTD;Integrated Security=True";
            SqlConnection con2 = new SqlConnection(connectionString);
            con2.Open();
            string query = "SELECT DISTINCT ITEMDESC  FROM dbo.IV00101"; 
            //select Convert(nvarchar(50),Item_Description)+ ':' +Convert(nvarchar(50),Item#) as Combined from Carimed
            SqlCommand cmd2 = new SqlCommand(query, con2);
    
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string cari_des = dr2.GetString(dr2.GetOrdinal("ITEMDESC"));
                suggestComboBox1.Items.Add(cari_des.Trim());
            }
            //con2.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
