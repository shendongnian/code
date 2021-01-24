        string json = String.Empty;
        using (SqlConnection connection = new SqlConnection("... your connection string ...") {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT FROM... FOR JSON PATH", connection) {
                json = command.ExecuteScalar();
            }
        }
