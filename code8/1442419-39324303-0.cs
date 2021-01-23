    using (MySqlConnection con = new MySqlConnection())
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings("conio").ConnectionString();
        string queryText = "INSERT INTO clientsDetails (clientName, companyAddress, city, contactPersonName, contactNumber1) Values(@clientName, @companyAddress, @city, @contactPersonName, @contactNumber1)";
        using (MySqlCommand cmd = new MySqlCommand(queryText, con))
        {
            cmd.Parameters.AddWithValue("@clientName", companyName.Text);
            cmd.Parameters.AddWithValue("@companyAddress", companyAddress.Text);
            cmd.Parameters.AddWithValue("@city", companyCity.Text);
            cmd.Parameters.AddWithValue("@contactPersonName", concernPersonName.Text);
            cmd.Parameters.AddWithValue("@contactNumber1", countryCodeWithNumber);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
