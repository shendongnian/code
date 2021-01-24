            try
            {
                using (SqlConnection connection = new SqlConnection(
               connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
