    static void test()
    {
        try
        {
            var connection = new SqlConnection(connectionString);
            connection.InfoMessage += Connection_InfoMessage;
            var command = new SqlCommand("dbo.test", connection) { CommandType = CommandType.StoredProcedure };
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
    
    private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        Console.WriteLine(e.Message);
    }
