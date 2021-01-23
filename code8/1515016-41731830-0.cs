    public static void Main()
    {
        HidDevice device;
        
        // device declaration
        device.Inserted += Device_Inserted;
        device.Removed += Device_Removed;
    }
    private static void Device_Removed()
    {
        // Some stuff to do when device is removed
        throw new NotImplementedException();
    }
    private static void Device_Inserted()
    {
        // Some stuff to do when device is inserted
        throw new NotImplementedException();
    }
