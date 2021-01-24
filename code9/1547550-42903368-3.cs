    using (OracleConnection connection = new OracleConnection())
    {
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString;
        connection.Open();
    
        using (OracleCommand command = connection.CreateCommand())
        {
            command.CommandText = "TEST_PROCEDURE";
            command.CommandType = CommandType.StoredProcedure;
    
            OracleParameter param1 = new OracleParameter("P_ID", OracleType.Number);
            param1.Direction = ParameterDirection.Output;
            command.Parameters.Add(param1);
    
            OracleParameter param2 = new OracleParameter("P_NAME", OracleType.VarChar);
            param2.Size = 4000;
            param2.Direction = ParameterDirection.Output;
            command.Parameters.Add(param2);
    
            using (command.ExecuteReader())
            {
                Console.WriteLine($"Output: [{param2.Value}]");
            }
        }
    }
