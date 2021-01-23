        private void FillComboBox(ComboBox Box, SqlConnection con)
        {
            LogInpanel_ComboBox.Items.Clear();
            using (con)
            {
                SqlCommand com = new SqlCommand("Select Id From UsersTable", con);
                con.Open();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogInpanel_ComboBox.Items.Add(reader["Id"].ToString());
                    }
                    reader.Close();
                }
            }
            con.Close();
        }
