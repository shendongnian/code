            string queryString = "select Col_Length('Contents','Title') as columnLengthh";
            string connectionString = @"your con string";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    Console.WriteLine("columnLengthh = {0}", result);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                connection.Close();
            }
