    public int GetUserId(byte[] fingerPrintData)
    {
        var connStr = "...";
        var conn = new MySqlConnection(connStr);
        var userId = -1;
        try
        {
            conn.Open();
    
            var sql = "SELECT UserId, FingerPrintData FROM FingerPrint WHERE Continent = @FingerPrintHash";
            var command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@FingerPrintHash", fingerPrintData);
            var reader = command.ExecuteReader();
    
            while (reader.Read())
            {
                byte[] data = reader["FingerPrintData"];
                userId  = reader["UserId"];
    
                if (DoFingerPrintsMatch(fingerPrintData, data))
                {
                    break;
                }
    
            }
    
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    
    
        return userId;
    }
