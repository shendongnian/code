    public void Enroll_Customer()
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["PortfolioMgmtConnectionString"].ConnectionString;
    
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand("spAddNewCustomer", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstNameTextBox.Text);
            cmd.Parameters.AddWithValue("@Gender", GenderDropDownList.SelectedValue);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
