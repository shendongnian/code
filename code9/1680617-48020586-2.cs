    string commandText = "INSERT INTO Stocks VALUES(@stock_no, @txt_qty,@txt_gem_weight,@txt_cost)";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@stock_no", SqlDbType.Int);
        command.Parameters["@stock_no"].Value = txt_stock_no.Text;
        ....
        // do the same for other parameters
    }
