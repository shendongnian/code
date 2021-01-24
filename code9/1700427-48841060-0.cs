    int ID;
    ID = int.Parse(med_ID.Text);
    using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HCLRURF\SQLEXPRESS;Initial Catalog=ydb;Integrated Security=True"))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT Quantite FROM TabRestitue WHERE Tab_medID= @medId ORDER BY DateDePeremption ASC "))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@medId", "%" + ID + "%");
    
            conn.Open();
            cmd.Connection = conn;
    
            DataSet dt = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
            }
            dgrAffich_tab.DataSource = dt;
            conn.Close();
        }
    }
