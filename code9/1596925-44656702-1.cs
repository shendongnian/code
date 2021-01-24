    private static async Task<uint> getDeviceId(string macAddress)
    {
        uint returnvalue = 0;
        MySqlConnection connection;
        try
        {
            connection = new MySqlConnection(ConnectionString);
            
            var cmd = connection.CreateCommand() as MySqlCommand;
            //Don't EVER(!) use string concatenation like that in a query!
            cmd.CommandText = @"SELECT id FROM devices WHERE mac = @macAddress";
            cmd.Parameters.Add("@macAddress", MySqlDbType.VarChar, 18).Value = macAddress;
            connection.Open();
            Console.WriteLine(connection.State);
    
            DbDataReader reader = await cmd.ExecuteReaderAsync();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    returnvalue = await reader.GetFieldValueAsync<uint>(0);
                }
            }
            reader.Dispose();
            cmd.Dispose();
            
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return returnvalue;
    }
