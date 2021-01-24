    public static void Main()
    {
 
        ...
        mySerialPort.Open();
        
        TimeSpan waitTime = TimeSpan.FromMilliseconds(500);
        if(DataReceivedEvent.WaitOne(waitTime) == false)
        {
             // Failure: Data has not been received within waitTime
             // Print text
        }
        else
        {
             // Success: Data has been received within waitTime
             // Do work
        }
        
        ...
    }
