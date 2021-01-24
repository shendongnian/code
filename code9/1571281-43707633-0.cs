    public static int AddCustomer(Customer customer)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = "server=127.0.0.1;uid=root;" +
            "pwd=12345;database=test;"
        string strInsertStatement =
            "INSERT Customers " +
            "(Name, Address, City, State, ZipCode) " +
            "VALUES (@Name, @Address, @City, @State, @ZipCode)";
        MySql.Data.MySqlClient.MySqlCommand insertCommand =
            new MySql.Data.MySqlClient.MySqlCommand(strInsertStatement);
        insertCommand.Parameters.AddWithValue(
            "@Name", customer.strFirstName);
        insertCommand.Parameters.AddWithValue(
            "@Address", customer.strStreetName);
        insertCommand.Parameters.AddWithValue(
            "@City", customer.strCity);
        insertCommand.Parameters.AddWithValue(
            "@State", customer.strState);
        insertCommand.Parameters.AddWithValue(
            "@ZipCode", customer.strPhoneNumber);
        try
        {
            connection.Open();
            insertCommand.Connection = connection;
            insertCommand.ExecuteNonQuery();
            string strSelectStatement =
                "SELECT IDENT_CURRENT('Customers') FROM Customers";
            MySql.Data.MySqlClient.MySqlCommand selectCommand =
                new MySql.Data.MySqlClient.MySqlCommand(strSelectStatement, connection);
            int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
            return customerID;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.ToString());
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
