    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM store", connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
