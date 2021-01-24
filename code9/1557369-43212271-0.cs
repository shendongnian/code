    try
    {
        using (connection = new SqlConnection(connectionString))
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            var startTime = DateTime.Now; // I added this line 
    
            for (int i = 0; i < 200; i++)
            {
                using (SqlCommand command = new SqlCommand("TimeSlotAppointments", connection))
                {
                    command.Transaction = transaction;
    
                    command.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter parameter1 = command.Parameters.Add("@StartTime", SqlDbType.DateTime);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = startTime;  // I changed this line
    
                    command.ExecuteNonQuery();
                }
            }
    
            transaction.Commit();
        }
    }
    catch (SqlException e)
    {
        Console.Write(e);
        transaction.Rollback();
    }
    finally
    {
        connection.Close();
        connection.Dispose();
    }
