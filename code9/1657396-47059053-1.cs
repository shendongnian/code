    foreach (var row in textboxes )
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string saveQuery = "INSERT into " + myTable+ " (name, date) VALUES (@name, @date)";
            using (SqlCommand querySave = new SqlCommand(saveQuery))
            {
                querySave.Connection = connection;
				querySave.Parameters.Add("@name", SqlDbType.VarChar, 255).Value = (row == null) ? 0 : row.Text;
                querySave.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                            
                connection .Open();
                querySave.ExecuteNonQuery();
                connection .Close();
            }
        }
	}
