    private byte[] GetDesktopAsBytes() 
    {
        return serialize(GetDesktopAsBitmap()); // choose some way of getting bytes
    }
    private void send(byte[] data) 
    {
        // this should be a byte array length = sizeof(int)
        var dataSize = System.BitConverter.GetBytes(data.Length)
        // send dataSize first
        // then send data
    }
    private byte[] receive() 
    {
        var dataSizeRaw = /* receive 4 bytes from tcp conn */ ;
        var dataSize = System.BitConverter.ToInt32(dataSizeRaw,0);
        
        var data = new byte[dataSize];
        // use tcp conn to fill data.
        return data;
    }
    
    // send(GetDesktopAsBytes());
