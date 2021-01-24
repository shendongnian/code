		using (SqlCommand cmd = new SqlCommand("Select * from users", con))
		{
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					user = new Users(reader["name"].ToString(), reader["image_path"].ToString());
					MessageBox.Show(user.ToString());
				}
			}
		}
