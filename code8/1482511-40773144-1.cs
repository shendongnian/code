      async void fillLiguanea()
        {
            comboBox2.Items.Clear();
            try
            {
                string connectionString = "Data Source=LPMSW09000012JD\\SQLEXPRESS;Initial Catalog=Pharmacies;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT * FROM " + comboBox4.Text;
                SqlCommand cmd = new SqlCommand(query, con);
                var reader = await cmd.ExecuteReaderAsync();
                comboBox2.BeginUpdate();
                while (reader.Read())
                {
                    string scode = reader.GetString(reader.GetOrdinal("code"));
                    comboBox2.Items.Add(scode);
                }
                comboBox2.EndUpdate();
                comboBox2.SelectedIndex = 0;
                // comboBox2.Sorted = true;
            }
