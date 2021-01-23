    while (reader.Read())
    {
        try
        {
            int paymenIdPos = reader.GetOrdinal("PaymentID");
            
            // if found --> read payment id 
            int paymentID = reader.GetInt32(paymenIdPos);
        }
        catch(IndexOutOfRangeException)
        {
            // if "PaymentID" is not found --> read the "ERrorNumber"
            int errorCode = reader.GetInt32("ErrorNumber");
        }           
    }
