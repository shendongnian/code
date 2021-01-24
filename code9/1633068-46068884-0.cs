    string connetionString = null;
    SqlConnection connection;
    SqlCommand command;
    string sql = null;
    SqlDataReader dataReader;
    connetionString = "Data Source=EVOPC18\\PMSMART;Initial Catalog=NORTHWND;User ID=test;Password=test";
    sql = "UPDATE Employees SET LastName = '" + Lnamestring + "', FirstName = '" + Fnamestring + "', Title = '" + Titelstring + "', TitleOfCourtesy = '" + ToCstring + "', BirthDate = '" + Birthdatestring + "', HireDate = '" + Hiredatestring + "', Address = '" + Adressstring + "', City = '" + Citystring + "', Region = '" + Regionstring + "', PostalCode = '" + Postalstring + "', Country = '" + Countrystring + "', HomePhone = '" + Phonestring + "', Extension = '" + Extensionsstring + "', Notes = '" + Notesstring + "', ReportsTo = '" + ReportTostring + "' WHERE EmployeeID = '" + IDstring + "'; ";
    connection = new SqlConnection(connetionString);
    try
    {
        connection.Open();
        command = new SqlCommand(sql, connection);
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(command);
        command.ExecuteNonQuery();
        command.Dispose();
        connection.Close();
        MessageBox.Show("workd ! ");
    
    }
    catch (Exception ex)
    {
        MessageBox.Show("Can not open connection ! ");
    }
