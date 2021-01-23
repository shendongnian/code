    public void PutRegistrationData(Registration registration)
    {
        registration.RegistrationDate = registrationDateTextBox.Text;
        registration.ProductCode = productComboBox.SelectedValue.ToString();
        registration.CustomerID = customerComboBox.SelectedValue.ToString();
    }
    public static int AddRegistration(Registration registration)
    {
         string insertStatement = @"INSERT INTO Registrations 
                (ProductCode, RegistrationDate, CustomerID) 
                VALUES (@ProductCode,@RegistrationDate, @CustomerID)";
        using(SqlConnection connection = TechSupportDB.GetConnection())
        using(SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
        {    
            insertCommand.Parameters.AddWithValue("@CustomerID", registration.CustomerID);
            insertCommand.Parameters.AddWithValue("@ProductCode", registration.ProductCode);
            insertCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
            connection.Open();
            int added = insertCommand.ExecuteNonQuery();
            return added;
       }
    }
