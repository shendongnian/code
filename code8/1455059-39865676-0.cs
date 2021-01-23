    try 
    {
        smtp.Send(mail); 
    }
    catch (Exception e) 
    {
        Debug.WriteLine("Exception Message: " + e.Message);
    }
