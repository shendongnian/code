    private void PopulateHobbies()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["constr"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from hobbies";
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = sdr["Hobby"].ToString();
                        item.Value = sdr["HobbyId"].ToString();
                        item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                        chkHobbies.Items.Add(item);
                    }
                }
               conn.Close();
            }
        }
    }
