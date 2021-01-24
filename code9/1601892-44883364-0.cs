    using (SqlConnection connection = new SqlConnection(""))
        {
            string query = "SELECT column FROM Datatable ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string coluna = reader.GetString(reader.GetOrdinal("column"));
                }
                connection.Close();
            }
        }
