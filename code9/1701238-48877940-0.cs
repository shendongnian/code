        public List<string> ReturnContactNames(string telephoneNumbers)
        {
            var retVal = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT * FROM Customers WHERE Phone IN (" + telephoneNumbers + ")", connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add((string)reader["ContactName"]);
                        }
                    }
                }
            }
            return retVal;
        }
