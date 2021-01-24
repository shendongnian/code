    string Sql = "select brand from [Car]";
            SqlConnection conn = new SqlConnection(@"path_to_db");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                Invoke(new Action(() => ComboBox1.Items.Add(DR[0])));
            }
