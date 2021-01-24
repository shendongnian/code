    try
    {
    	connection.Open();
    	command.Connection = connection;
    
    	command.CommandText = "SELECT SUM(Amount) FROM Payments WHERE TransactionDate <= @TransData;";
    	command.Parameter.AddWithValue("TransData", DateTime.Now);
    	chargesSoFar = (double?)command.ExecuteScalar();
    	connection.Close();
    }
    catch (Exception ex)
    {
    	MessageBox.Show("Error: " + ex.Message);
    }
