    string updateQuery = "UPDATE " + table_name + " SET creditorName = ?, amount = ?, interestRate = ?, ... WHERE savingsID = ?";
                        using (OleDbConnection con = new OleDbConnection(connectionString))
    {
        con.Open();
        using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, con))
        {
            updateCommand.CommandType = CommandType.Text;
            updateCommand.Parameters.AddWithValue("creditorName", TextBoxCreditorName.Text);
            updateCommand.Parameters.AddWithValue("amount", TextBoxPrincipalAmount.Text);
            updateCommand.Parameters.AddWithValue("interestRate", TextBoxInterestRate.Text);
            updateCommand.Parameters.AddWithValue("savingsID", tupleID);
            updateCommand.ExecuteNonQuery();
            con.Close();
        }
    }
