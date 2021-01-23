    protected void UpdateHobbies(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["constr"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "update hobbies set IsSelected = @IsSelected" +
                                  " where HobbyId=@HobbyId";
                cmd.Connection = conn;
                conn.Open();
                foreach (ListItem item in chkHobbies.Items)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                    cmd.Parameters.AddWithValue("@HobbyId", item.Value);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
