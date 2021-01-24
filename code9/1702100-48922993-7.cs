        private List<string> LoadMenuFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ToString();
            var retVal = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT menu_text FROM Table_1", connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add((string)reader["menu_text"]);
                        }
                    }
                }
            }
            return retVal;
        }
