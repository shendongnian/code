        public DataTable SelectData(string query)
        {
            using (var connection = new SqlConnection("myConnectionString"))
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                var dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                return dt;
            }
        }
