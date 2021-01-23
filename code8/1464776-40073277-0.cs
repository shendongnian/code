    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (var cmd = new SqlCommand("SELECT * FROM pProduct", conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string description = (string)reader["Description"];
                decimal price = (decimal)reader["Price"];
                products.Add(description, price);
                descriptionTextBox.AutoCompleteCustomSource.Add(description);
            }
        }
    }
