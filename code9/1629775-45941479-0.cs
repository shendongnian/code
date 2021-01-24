        public string GetPassword(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["deliverycon"]))
            {
                using (var command = new SqlCommand(@"select top 1 password from clients where email=@email", connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader["password"].ToString;
                    }
                }
            }
        }
