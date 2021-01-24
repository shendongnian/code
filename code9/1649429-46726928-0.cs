    public void pay_fighter(
        string fighterID, 
        DateTime paymentDay, 
        decimal paymentAmount, 
        string paymentDescr)
    {
        if (String.IsNullOrEmpty(fighterId))
        {
            return;
        }
        var query = 
            @"INSERT INTO PaymentInfo VALUES (
                @FighterId, 
                @PaymentDay, 
                @PaymentAmount, 
                @PaymentDescr)";
        var parameters = new[]
        {
            new SqlParameter
            {
                ParameterName = "@FigtherId",
                SqlDbType = SqlDbType.Int, // use correct type for column
                Value = fighterId
            },
            new SqlParameter
            {
                ParameterName = "@PaymentDay",
                SqlDbType = SqlDbType.DateTime, // use correct date type defined in column
                Value = paymentDay
            },
            new SqlParameter
            {
                ParameterName = "@PaymentAmount",
                SqlDbType = SqlDbType.Decimal, // use correct type for column
                Value = paymentAmount
            },
            new SqlParameter
            {
                ParameterName = "@PaymentDescr",
                SqlDbType = SqlDbType.VarChar, // use correct type for column
                Size = 100, // use size defined for column
                Value = paymentDescr
            }
        };
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddRange(parameters);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
