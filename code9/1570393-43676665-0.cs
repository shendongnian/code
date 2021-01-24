    string connectionString = "YourConnectionString";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT [DATE] FROM DB WHERE [Date] < DATEADD(dd, @MyInt, GETDATE())", connection))
                {                    
                    command.Parameters.Add(new SqlParameter("MyInt", myInt));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime date = reader.GetDateTime(0);
                        Console.WriteLine("Date: {0}",
                            date);
                    }
                }
            }
