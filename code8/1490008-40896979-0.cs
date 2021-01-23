    public static string IsConnected(string deviceVID, string devicePID)
    {
       //This line will look for the desired device and return it. 
       //If there is no match device will be null.
       var device = EnumerateDevices()
                .FirstOrDefault(x => x.VID == deviceVID && x.PID == devicePID);
       
       return device != null ? device.Path : "False";
    }
